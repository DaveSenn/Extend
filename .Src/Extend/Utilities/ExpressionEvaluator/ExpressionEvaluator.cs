#region Usings

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing the logic to get values from objects based on property expressions.
    /// </summary>
    public class ExpressionEvaluator
    {
        #region Constants

        /// <summary>
        ///     Gets or sets a value indicating whether caching is enabled or not.
        /// </summary>
        private static Boolean _enableCaching = true;

        /// <summary>
        ///     The characters used to separate expressions.
        /// </summary>
        private static readonly Char[] ExpressionPartSeparator = { '.' };

        /// <summary>
        ///     Characters used to mark the end of an index.
        /// </summary>
        private static readonly Char[] IndexExprEndChars = { ']', ')' };

        /// <summary>
        ///     Characters used to mark the start of an index.
        /// </summary>
        private static readonly Char[] IndexExprStartChars = { '[', '(' };

        /// <summary>
        ///     Gets or sets the cached property descriptors.
        /// </summary>
        /// <value>The cached property descriptors.</value>
        private static readonly ConcurrentDictionary<Type, List<PropertyInfo>> PropertyCache = new ConcurrentDictionary<Type, List<PropertyInfo>>();

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets a value determining whether property information will be cached or not.
        /// </summary>
        /// <value>A value determining whether property information will be cached or not.</value>
        [PublicAPI]
        public static Boolean EnableCaching
        {
            get => _enableCaching;
            set
            {
                _enableCaching = value;
                if ( !value )
                    PropertyCache.Clear();
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        ///     Gets the value represented by the specified expression from the given source object.
        /// </summary>
        /// <exception cref="ArgumentException">Could not find a property with the given name.</exception>
        /// <exception cref="ArgumentNullException">expression can not be null.</exception>
        /// <param name="expression">An expression matching a property name.</param>
        /// <param name="source">The source object.</param>
        /// <returns>Returns the value represented by the specified expression.</returns>
        public static Object GetValue( String expression, Object source )
        {
            if ( source == null )
                return null;

            if ( expression.IsEmpty() )
                throw new ArgumentNullException( nameof( expression ), $"{nameof( expression )} can not be null." );

            // Evaluate the expression
            return Evaluate( source, expression.Split( ExpressionPartSeparator ) );
        }

        #endregion

        #region Private Members

        /// <summary>
        ///     Evaluates the specified expression against the given object.
        /// </summary>
        /// <exception cref="ArgumentException">Could not find a property with the given name.</exception>
        /// <param name="source">The source object.</param>
        /// <param name="expressionParts">The expression parts to evaluate.</param>
        /// <returns>Returns the value represented by the specified expression.</returns>
        private static Object Evaluate(Object source, IList<String> expressionParts)
        {
            Object value;
            Int32 i;

            // Iterate through all expression parts
            for (value = source, i = 0; i < expressionParts.Count && value != null; i++)
            {
                var expression = expressionParts[i];
                var indexExpression = expression.IndexOfAny(IndexExprStartChars) >= 0;

                // Get the value represented by the current expression
                value = indexExpression == false
                    ? GetPropertyValue(value, expression)
                    : GetIndexedPropertyValue(value, expression);
            }

            return value;
        }

        /// <summary>
        ///     Gets the value of the property with the given name.
        /// </summary>
        /// <exception cref="ArgumentException">Could not find a property with the given name.</exception>
        /// <param name="source">The source object.</param>
        /// <param name="propertyName">Returns the property name.</param>
        /// <returns>Returns the value of the property with the given name.</returns>
        private static Object GetPropertyValue(Object source, String propertyName)
        {
            Object property;

            // Find the matching property information
            var propertyInfo = GetPropertiesFromCache(source)
                .Find(x => x.Name.CompareOrdinalIgnoreCase(propertyName));

            // Get the value of the property
            if (propertyInfo != null)
                property = propertyInfo.GetValueWithoutIndex(source);
            else
                throw new ArgumentException($"Could not find a property with name '{propertyName}'.", nameof(propertyInfo));

            return property;
        }

        /// <summary>
        /// Gets the value of the property represented by the given index expression.
        /// </summary>
        /// <exception cref="ArgumentException">Could not find a property with the given name.</exception>
        /// <param name="source">The source object.</param>
        /// <param name="expression">The expression to evaluate.</param>
        /// <returns>Returns the value of the property represented by the given expression.</returns>
        private static Object GetIndexedPropertyValue( Object source, String expression )
        {
            Object propertyValue;
            var intIndex = false;

            // Get the index expression and validate it
            var indexExpressionStart = expression.IndexOfAny( IndexExprStartChars );
            var indexExpressionEnd = expression.IndexOfAny( IndexExprEndChars, indexExpressionStart + 1 );
            if ( indexExpressionStart < 0 || indexExpressionEnd < 0 || indexExpressionEnd == indexExpressionStart + 1 )
                throw new ArgumentException( $"Invalid index in expression '{expression}'." );

            // Get the index
            var index = expression.Substring( indexExpressionStart + 1, indexExpressionEnd - indexExpressionStart - 1 )
                                  .Trim();

            // Can be nameless if the expression only contains an index expression and no property name (valid in case source is a collection)
            String propertyName = null;
            if ( indexExpressionStart != 0 )
                propertyName = expression.Substring( 0, indexExpressionStart );

            // Get the index value (the value can be a int or a string)
            Object indexValue = null;
            var parsedIndex = -1;
            if ( index.Length != 0 )
                if ( index[0] == '"' && index[index.Length - 1] == '"' || index[0] == '\'' && index[index.Length - 1] == '\'' )
                    // Must be a string value => remove the quotes
                    indexValue = index.Substring( 1, index.Length - 2 );
                else
                {
                    // Check if is int or not
                    if ( Char.IsDigit( index[0] ) )
                    {
                        // Treat it as a number
                        intIndex = index.TryParsInt32( out parsedIndex );
                        if ( intIndex )
                            indexValue = parsedIndex;
                        else
                            indexValue = index;
                    }
                    else
                    {
                        // Treat as a string
                        indexValue = index;
                    }
                }
            
            // Get the collection of which we should access the index
            var collectionProperty = propertyName.IsNotEmpty()
                ? GetPropertyValue( source, propertyName )
                : source;
            
            // Check if we are working with an array or a list
            IList listProperty;
            var arrayProperty = collectionProperty as Array;
            if ( arrayProperty != null && intIndex )
                propertyValue = arrayProperty.GetValue( parsedIndex );
            else if ( ( listProperty = collectionProperty as IList ) != null && intIndex )
                propertyValue = listProperty[(Int32) indexValue];
            else
            {
                // TODO: In which case do we enter this block?

                // Get the Item property
                var propertyInfo = collectionProperty.GetType()
                                                     .GetRuntimeProperty( "Item" );

                // Get the value from the property
                if ( propertyInfo != null )
                    propertyValue = propertyInfo.GetValue( collectionProperty, new[] { indexValue } );
                else
                    throw new ArgumentException( $"Unable to access index represented by '{expression}', could not find a 'Item' method." );
            }

            return propertyValue;
        }


        /// <summary>
        ///     Gets the properties of the given object from the cache.
        /// </summary>
        /// <remarks>
        ///     Uses reflection to get the properties if they are not cached yet.
        /// </remarks>
        /// <param name="source">The object.</param>
        /// <returns>Returns the properties of the given object.</returns>
        private static List<PropertyInfo> GetPropertiesFromCache( Object source )
        {
            var containerType = source.GetType();

            // Check if we should cache the properties or not
            if ( !EnableCaching )
                return containerType
                    .GetPublicProperties()
                    .ToList();

            if (PropertyCache.TryGetValue(containerType, out List<PropertyInfo> properties))
                return properties;

            properties = containerType.GetPublicProperties()
                                      .ToList();

            // Update the cache
            PropertyCache.TryAdd( containerType, properties );

            return properties;
        }

        

        #endregion
    }
}