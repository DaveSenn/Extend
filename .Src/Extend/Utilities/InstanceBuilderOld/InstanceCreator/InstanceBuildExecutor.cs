#region Usings

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class creating instances based on instance builders.
    /// </summary>
    public static class InstanceBuildExecutor
    {
        #region Properties

        /// <summary>
        ///     Gets the default factories per type.
        /// </summary>
        /// <value>The default factories per type.</value>
        public static ConcurrentDictionary<Type, Func<IInstanceValueArguments, Object>> DefaultFactories { get; } =
            new ConcurrentDictionary<Type, Func<IInstanceValueArguments, Object>>();

        /// <summary>
        ///     Gets a list of child member filters.
        /// </summary>
        /// <remarks>
        ///     The child members of types matching any of the this filters will not be set.
        ///     E.g. used to ignore Framework types such as List{T}.
        /// </remarks>
        /// <value>A list of child member filters.</value>
        public static ConcurrentBag<IInstanceCreatorFilter> DefaultChildMemberFilters { get; } = new ConcurrentBag<IInstanceCreatorFilter>();

        /// <summary>
        ///     Gets a list of member filters.
        /// </summary>
        /// <remarks>
        ///     The members matching any of the this filters will not be set.
        /// </remarks>
        /// <value>A list of member filters.</value>
        public static ConcurrentBag<IInstanceCreatorFilter> DefaultMemberFilters { get; } = new ConcurrentBag<IInstanceCreatorFilter>();

        /// <summary>
        ///     Gets or sets a value determining whether collections should get populated or not.
        /// </summary>
        /// <value>A value determining whether collections should get populated or not.</value>
        public static Boolean PopulateCollections { get; set; } = true;

        /// <summary>
        ///     Gets or sets the minimum number of items to generate for a collection.
        /// </summary>
        /// <value>The minimum number of items to generate for a collection.</value>
        public static Int32 CollectionMinCount { get; set; } = 2;

        /// <summary>
        ///     Gets or sets the maximum number of items to generate for a collection.
        /// </summary>
        /// <value>The maximum number of items to generate for a collection.</value>
        public static Int32 CollectionMaxCount { get; set; } = 20;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes the <see cref="InstanceBuildExecutor" /> class.
        /// </summary>
        static InstanceBuildExecutor()
        {
            CreateDefaultFactories();
            CreateDefaultChildMemberFilters();
        }

        #endregion

        #region Public Members

        /// <summary>
        ///     Creates an instance of the given type using the given factories.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <exception cref="ArgumentNullException">factories can not be null.</exception>
        /// <param name="type">The type of the instance to create.</param>
        /// <param name="factories">The factories to use.</param>
        /// <returns>Returns the new created instance.</returns>
        public static Object BuildInstance( Type type, IEnumerable<IInstanceValueFactory> factories )
        {
            type.ThrowIfNull( nameof( type ) );
            factories.ThrowIfNull( nameof( factories ) );

            var instance = CreateInstance( type );
            SetProperties( instance, factories );

            return instance;
        }

        #endregion

        #region Internal Helpers

        /// <summary>
        ///     Sets all properties of the given instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="factories">THe factories to use.</param>
        private static void SetProperties( Object instance, IEnumerable<IInstanceValueFactory> factories )
        {
            var propertyInfos = GetProperties( instance );

            propertyInfos.ForEach( x =>
            {
                //Create arguments for the current property
                var arguments = new InstanceValueArguments( x.PropertyType, x.PropertyType.Name, x, instance );

                //Set the property if it should not be ignored
                if ( DefaultMemberFilters.NotAny( y => y.Matches( arguments ) ) )
                    SetPropertyValue( arguments, factories );
            } );
        }

        /// <summary>
        ///     Sets the value of the specified property.
        /// </summary>
        /// <param name="arguments">The factory arguments.</param>
        /// <param name="factories">The value factories.</param>
        private static void SetPropertyValue( IInstanceValueArguments arguments, IEnumerable<IInstanceValueFactory> factories )
        {
            var value = GetPropertyValue( arguments, factories );
            arguments.PropertyInfo.SetValue( arguments.PropertyOwner, value, null );
        }

        /// <summary>
        ///     Gets the value for the specified property.
        /// </summary>
        /// <param name="arguments">The factory arguments.</param>
        /// <param name="factories">The custom factories.</param>
        /// <returns>Returns the value for the property.</returns>
        private static Object GetPropertyValue( IInstanceValueArguments arguments, IEnumerable<IInstanceValueFactory> factories )
        {
            //Try custom factory
            var factory = GetMatchingCustomFactory( arguments, factories );
            if ( factory != null )
                return factory.Factory( arguments );

            //Try default factory
            var defaultFactory = GetDefaultFactory( arguments.PropertyType );

            //Use default factory or activator
            return defaultFactory != null ? defaultFactory( arguments ) : CreateInstanceUsingAcrivator( arguments, factories );
        }

        /// <summary>
        ///     Checks if the given instance is an collection and if some values should be added to it.
        /// </summary>
        /// <param name="arguments">The value arguments.</param>
        /// <param name="instance">The instance to check.</param>
        /// <param name="factories">The value factories.</param>
        /// <returns>Returns the instance.</returns>
        private static Object CheckForCollection( IInstanceValueArguments arguments, Object instance, IEnumerable<IInstanceValueFactory> factories )
        {
            if ( !PopulateCollections || instance == null )
                return instance;

            var instanceType = instance.GetType();
#if PORTABLE45
            var interfaces = instanceType.GetTypeInfo()
                                         .ImplementedInterfaces.ToList();
#elif NET40
            var interfaces = instanceType.GetInterfaces()
                                         .ToList();
#endif

            //Check if instance implements ICollection{T}
            if ( interfaces.NotAny( x => x.Name == "ICollection`1" ) )
                return instance;

            //Get generic parameter type
#if PORTABLE45
            var genericArgument = instanceType.GetTypeInfo()
                                              .GenericTypeArguments.FirstOrDefault();
#elif NET40
            var genericArgument = instanceType.GetGenericArguments()
                                              .FirstOrDefault();
#endif

            return genericArgument == null ? instance : PopulateCollection( instance, genericArgument, factories );
        }

        /// <summary>
        ///     Populates the given collection.
        /// </summary>
        /// <param name="collection">The collection to populate.</param>
        /// <param name="collectionItemType">The type of the items.</param>
        /// <param name="factories">The value factories.</param>
        /// <returns>Returns the collection.</returns>
        private static Object PopulateCollection( Object collection, Type collectionItemType, IEnumerable<IInstanceValueFactory> factories )
        {
            if ( !PopulateCollections )
                return collection;

            //Get the add method
#if PORTABLE45
            var addMethod = collection.GetType()
                                      .GetRuntimeMethod( "Add", new[] { collectionItemType } );
#elif NET40
            var addMethod = collection.GetType()
                                      .GetMethod( "Add" );
#endif

            if ( addMethod == null )
                return collection;

            //Create arguments for the collection items
            var itemArguments = new InstanceValueArguments( collectionItemType, collectionItemType.Name, null, collection );

            //Try custom factory
            var customFactory = GetMatchingCustomFactory( itemArguments, factories );

            //Try default factory
            var defaultFactory = GetDefaultFactory( collectionItemType );

            for ( var i = 0; i < RandomValueEx.GetRandomInt32( CollectionMinCount, CollectionMaxCount + 1 ); i++ )
            {
                Object newItem;
                if ( customFactory != null )
                    newItem = customFactory.Factory( itemArguments );
                else if ( defaultFactory != null )
                    newItem = defaultFactory( itemArguments );
                else
                    newItem = CreateInstanceUsingAcrivator( itemArguments, factories );

                addMethod.Invoke( collection, new[] { newItem } );
            }

            return collection;
        }

        /// <summary>
        ///     Gets the default factory for the given type.
        /// </summary>
        /// <param name="type">The type to get the factory for.</param>
        /// <returns>Returns the matching default factory, or null if no matching factory was found.</returns>
        private static Func<IInstanceValueArguments, Object> GetDefaultFactory( Type type )
        {
            //Try default factory
            Func<IInstanceValueArguments, Object> defaultFactory = null;
            DefaultFactories.TryGetValue( type, out defaultFactory );

            if ( defaultFactory != null )
                return defaultFactory;

            //Check if type is nullable
            var nullableType = GetTypeFromNullable( type );
            if ( nullableType != null )
                DefaultFactories.TryGetValue( nullableType, out defaultFactory );

            return defaultFactory;
        }

        /// <summary>
        ///     Creates an instance of the specified type using the Activator class.
        /// </summary>
        /// <param name="arguments">The value arguments.</param>
        /// <param name="factories">The value factories.</param>
        /// <returns>Returns the new created instance.</returns>
        private static Object CreateInstanceUsingAcrivator( IInstanceValueArguments arguments, IEnumerable<IInstanceValueFactory> factories )
        {
            //Check if type is an array.
            var instance = CheckForSupportedTypes( arguments, factories );
            if ( instance != null )
                return CheckForCollection( arguments, instance, factories );

            //Create type using activator class
            try
            {
                instance = Activator.CreateInstance( arguments.PropertyType );
            }
            catch ( Exception ex )
            {
                throw new InvalidOperationException( $"Failed to create an instance of the following type: '{arguments.PropertyType}'", ex );
            }
            if ( DefaultChildMemberFilters.NotAny( x => x.Matches( arguments ) ) )
                SetProperties( instance, factories );

            return CheckForCollection( arguments, instance, factories );
        }

        /// <summary>
        ///     Checks if the given type is supported.
        /// </summary>
        /// <param name="arguments">The arguments representing the type.</param>
        /// <param name="factories">The factories to use.</param>
        /// <returns>Returns the new creates instance, or null if the type is not supported.</returns>
        private static Object CheckForSupportedTypes( IInstanceValueArguments arguments, IEnumerable<IInstanceValueFactory> factories )
        {
            //Check if type is an array.
            var instance = CheckForArray( arguments, factories );
            if ( instance != null )
                return instance;

            //Check if type is IEnumerable{T}
            instance = CheckForIEnumerable( arguments );
            return instance;
        }

        /// <summary>
        ///     Checks if the given type is an IEnumerable{T}.
        /// </summary>
        /// <param name="arguments">The type to check.</param>
        /// <returns>Returns the new created IEnumerable{T}, or null if the type is not an IEnumerable{T}.</returns>
        private static Object CheckForIEnumerable( IInstanceValueArguments arguments )
        {
#if PORTABLE45

            //Check for IEnumerable<T>
            var isIEnumarable = arguments.PropertyType.GetTypeInfo()
                                         .IsGenericType && arguments.PropertyType.GetGenericTypeDefinition() == typeof (IEnumerable<>);
#elif NET40
    //Check for IEnumerable<T>
            var isIEnumarable = arguments.PropertyType.IsGenericType && arguments.PropertyType.GetGenericTypeDefinition() == typeof (IEnumerable<>);
#endif

            if ( !isIEnumarable )
                return null;

#if PORTABLE45

            var concreteType = typeof (List<>).MakeGenericType( arguments.PropertyType.GenericTypeArguments );
#elif NET40
            var concreteType = typeof (List<>).MakeGenericType( arguments.PropertyType.GetGenericArguments() );
#endif

            return Activator.CreateInstance( concreteType );
        }

        /// <summary>
        ///     Checks if the given type is an array.
        /// </summary>
        /// <param name="arguments">The type to check.</param>
        /// <param name="factories">The factories to use to create the array values.</param>
        /// <returns>Returns the new created array, or null if the type is not an array.</returns>
        private static Object CheckForArray( IInstanceValueArguments arguments, IEnumerable<IInstanceValueFactory> factories )
        {
            //Aboard if type is not an array
            if ( !arguments.PropertyType.IsArray )
                return null;

            //Create the array
            var elementType = arguments.PropertyType.GetElementType();
            var array = Array.CreateInstance( elementType, PopulateCollections ? RandomValueEx.GetRandomInt32( CollectionMinCount, CollectionMaxCount ) : 0 );

            //Create arguments for the collection items
            var itemArguments = new InstanceValueArguments( elementType, elementType.Name, null, array );

            //Try custom factory
            var customFactory = GetMatchingCustomFactory( itemArguments, factories );

            //Try default factory
            var defaultFactory = GetDefaultFactory( elementType );

            //Add items
            for ( var i = 0; i < array.Length; i++ )
            {
                Object newItem;
                if ( customFactory != null )
                    newItem = customFactory.Factory( itemArguments );
                else if ( defaultFactory != null )
                    newItem = defaultFactory( itemArguments );
                else
                    newItem = CreateInstanceUsingAcrivator( itemArguments, factories );

                array.SetValue( newItem, i );
            }

            return array;
        }

        /// <summary>
        ///     Gets the matching custom value factory, or null if none matches.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">More than one matching factory found.</exception>
        /// <param name="arguments">The arguments to check the factories against.</param>
        /// <param name="factories">The factories.</param>
        /// <returns>Returns the matching factory, or null.</returns>
        private static IInstanceValueFactory GetMatchingCustomFactory( IInstanceValueArguments arguments, IEnumerable<IInstanceValueFactory> factories )
        {
            var matchingFactories = factories.Where( x => x.Matches( arguments ) )
                                             .ToList();
            if ( matchingFactories.NotAny() )
                return null;

            if ( matchingFactories.Count == 1 )
                return matchingFactories.Single();

            throw new ArgumentOutOfRangeException( nameof( factories ),
                                                   factories,
                                                   $"Factory miss match, '{matchingFactories.Count}' do match the arguments, only one match is allowed. Please check your factory conditions." );
        }

        /// <summary>
        ///     Creates an instance of the given type.
        /// </summary>
        /// <param name="type">The type of the instance to create.</param>
        /// <returns>Returns the new created instance.</returns>
        private static Object CreateInstance( Type type )
        {
            try
            {
                var instance = Activator.CreateInstance( type );
                return instance;
            }
            catch ( Exception ex )
            {
                throw new InvalidOperationException( $"Failed to create an instance of the following type: '{type}'", ex );
            }
        }

        /// <summary>
        ///     Gets the property info of each property.
        /// </summary>
        /// <param name="instance">The instance to get the properties of.</param>
        /// <returns>Returns the property infos.</returns>
        private static IEnumerable<PropertyInfo> GetProperties( Object instance )
        {
            var type = instance.GetType();

#if PORTABLE45

            var propertyInfos = type.GetTypeInfo()
                                    .DeclaredProperties;
#elif NET40
            var propertyInfos = type.GetProperties( BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly );
#endif

            return propertyInfos.Where( x => x.CanWrite );
        }

        /// <summary>
        ///     Gets the 'inner' type from a nullable type.
        /// </summary>
        /// <param name="possibleNullableType">The possible nullable type.</param>
        /// <returns>Returns the inner type, or null if the given type is not a nullable.</returns>
        private static Type GetTypeFromNullable( Type possibleNullableType )
        {
#if PORTABLE45
            var typeInfo = possibleNullableType.GetTypeInfo();
            if ( !( typeInfo.IsGenericType && possibleNullableType.GetGenericTypeDefinition() == typeof (Nullable<>) ) )
                return null;

            return typeInfo.GenericTypeArguments.FirstOrDefault();
#elif NET40
            if ( !( possibleNullableType.IsGenericType && possibleNullableType.GetGenericTypeDefinition() == typeof (Nullable<>) ) )
                return null;

            return possibleNullableType.GetGenericArguments()
                                       .FirstOrDefault();
#endif
        }

        #endregion

        #region Init

        /// <summary>
        ///     Creates the default factories.
        /// </summary>
        private static void CreateDefaultFactories()
        {
            DefaultFactories.AddOrUpdate( typeof (Int16), x => RandomValueEx.GetRandomInt16(), ( type, func ) => x => RandomValueEx.GetRandomInt16() );
            DefaultFactories.AddOrUpdate( typeof (Int32), x => RandomValueEx.GetRandomInt32(), ( type, func ) => x => RandomValueEx.GetRandomInt32() );
            DefaultFactories.AddOrUpdate( typeof (Int64), x => RandomValueEx.GetRandomInt64(), ( type, func ) => x => RandomValueEx.GetRandomInt64() );
            DefaultFactories.AddOrUpdate( typeof (String), x => RandomValueEx.GetRandomString(), ( type, func ) => x => RandomValueEx.GetRandomString() );
            DefaultFactories.AddOrUpdate( typeof (Boolean), x => RandomValueEx.GetRandomBoolean(), ( type, func ) => x => RandomValueEx.GetRandomBoolean() );
            DefaultFactories.AddOrUpdate( typeof (DateTime), x => RandomValueEx.GetRandomDateTime(), ( type, func ) => x => RandomValueEx.GetRandomDateTime() );
        }

        /// <summary>
        ///     Creates the default child member filters.
        /// </summary>
        private static void CreateDefaultChildMemberFilters()
        {
            DefaultChildMemberFilters.Add( new ExpressionInstanceCreatorFilter( x => x.PropertyType.IsMicrosoftType(),
                                                                                "Microsoft Types Filter",
                                                                                "Filters all types from Microsoft. (Should include all framework types.)" ) );
        }

        #endregion
    }
}