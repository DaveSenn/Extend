using System;
using System.Linq.Expressions;

namespace PortableExtensions
{
    /// <summary>
    /// Class containing some extension methods for <see cref="Object"/>.
    /// </summary>
    public static class ObjectEx
    {
        /// <summary>
        /// Gets whether the given <see cref="Object"/> is null or not.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to check.</param>
        /// <returns>A value of true if the <see cref="Object"/> is null, otherwise false.</returns>
        public static Boolean IsNull( this Object obj )
        {
            return obj == null;
        }

        /// <summary>
        /// Gets whether the given <see cref="Object"/> is NOT null or not.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to check.</param>
        /// <returns>A value of true if the <see cref="Object"/> is NOT null, otherwise false.</returns>
        public static Boolean IsNotNull( this Object obj )
        {
            return obj != null;
        }

        /// <summary>
        /// Throws a <see cref="ArgumentNullException"/> exception if the given property is null.
        /// </summary>
        /// <remarks>
        /// If the
        /// <paramref name="errorMessage"/>is null, this method will use the following default message: "{ParameterName} can not be null." (Use this overload for checking if a property of an object is null.)
        /// </remarks>
        /// <typeparam name="TObject">The type of the object which owns to property.</typeparam> <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="obj">The object which contains the parameter or any object.</param>
        /// <param name="property">The parameter to check.</param>
        /// <param name="propertyName">An expression which has the property as body.</param>
        /// <param name="errorMessage">The text used as exception message if the parameter is null.</param>
        public static void ThrowIfNull<TObject, TProperty>( this TObject obj, TProperty property, Expression<Func<TObject, TProperty>> propertyName, String errorMessage = null )
        {
            if( property == null )
            {
                var parameterName = ( propertyName.Body as MemberExpression ?? ( (UnaryExpression)propertyName.Body ).Operand as MemberExpression ).Member.Name;
                throw new ArgumentNullException ( parameterName, errorMessage ?? String.Format ( "{0} can not be null.", parameterName ) );
            }
        }

        /// <summary>
        /// Throws a <see cref="ArgumentNullException"/> exception if the given parameter is null.
        /// </summary>
        /// <remarks>
        /// If the
        /// <paramref name="errorMessage"/>is null, this method will use the following default message: "{ParameterName} can not be null." (Use this methods for checking if a parameter is null.)
        /// </remarks>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="fieldName">An expression which has the parameter as body.</param>
        /// <param name="errorMessage">The text used as exception message if the parameter is null.</param>
        public static void ThrowIfNull<TParameter>( this TParameter parameter, Expression<Func<TParameter>> fieldName, String errorMessage = null )
        {
            if( parameter == null )
            {
                var parameterName = ( fieldName.Body as MemberExpression ?? ( (UnaryExpression)fieldName.Body ).Operand as MemberExpression ).Member.Name;
                throw new ArgumentNullException ( parameterName, errorMessage ?? String.Format ( "{0} can not be null.", parameterName ) );
            }
        }

        /// <summary>
        /// Gets the name of the member of the given <see cref="Expression{T}"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">The field expression can not be null.</exception> <typeparam name="TObject">The type of the source object.</typeparam> <typeparam name="TField">The type of the member of the given <see cref="Expression{T}"/>.</typeparam>
        /// <param name="obj">The source object.</param>
        /// <param name="fieldName">The member of the given see cref="Expression{T}"/></param>
        /// <returns>The name of the the given member as see cref="String"/>.</returns>
        public static String GetName<TObject, TField>( this TObject obj, Expression<Func<TObject, TField>> fieldName )
        {
            if( fieldName == null )
                throw new ArgumentNullException ( "field", "The field expression can not be null." );

            return ( fieldName.Body as MemberExpression ?? ( (UnaryExpression)fieldName.Body ).Operand as MemberExpression ).Member.Name;
        }
    }
}