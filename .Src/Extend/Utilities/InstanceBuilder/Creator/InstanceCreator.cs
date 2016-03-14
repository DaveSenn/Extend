#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing the logic to create instances.
    /// </summary>
    public static class InstanceCreator
    {
        #region Properties

        /// <summary>
        ///     Gets the default factories.
        /// </summary>
        /// <remarks>The default factories.</remarks>
        public static List<IInstanceFactory> DefaultFactories { get; } = new List<IInstanceFactory>();

        /// <summary>
        ///     Gets the default member selection rule.
        /// </summary>
        /// <value>The default member selection rule.</value>
        public static List<IMemberSelectionRule> DefaultMemberSelectionRules { get; } = new List<IMemberSelectionRule>();

        /// <summary>
        ///     Gets the default member children selection rule.
        /// </summary>
        /// <value>The default member children selection rule.</value>
        public static List<IMemberSelectionRule> DefaultMemberChildreSelectionRules { get; } = new List<IMemberSelectionRule>();

        /// <summary>
        ///     Gets or sets a value determining whether collections should get populated or not.
        /// </summary>
        /// <value>A value determining whether collections should get populated or not.</value>
        public static Boolean PopulateCollections { get; set; } = true;

        /// <summary>
        ///     Gets or sets the minimum number of items to generate for a collection.
        /// </summary>
        /// <value>The minimum number of items to generate for a collection.</value>
        public static Int32 PopulateCollectionsMinCount { get; set; } = 2;

        /// <summary>
        ///     Gets or sets the maximum number of items to generate for a collection.
        /// </summary>
        /// <value>The maximum number of items to generate for a collection.</value>
        public static Int32 PopulateCollectionsMaxCount { get; set; } = 10;

        /// <summary>
        ///     Gets or sets the name used for anonyoumous items.
        /// </summary>
        /// <remarks>
        ///     Targets collection items.
        /// </remarks>
        /// <value>The name used for anonyoumous items.</value>
        public static String AnonymousItemName { get; set; } = "[AnonymousItem]";

        /// <summary>
        ///     Gets or sets the <see cref="IMemberSelectionRuleInspector" /> used to inspect member selection rules.
        /// </summary>
        /// <value>The <see cref="IMemberSelectionRuleInspector" /> used to inspect member selection rules.</value>
        public static IMemberSelectionRuleInspector RuleInspector { get; set; } = new MemberSelectionRuleInspector();

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes the <see cref="InstanceCreator" /> class.
        /// </summary>
        static InstanceCreator()
        {
            CreateDefaultFactories();
            CreateDefaultMemberSelectionRules();
            CreateDefaultMemberChildreSelectionRules();
        }

        #endregion

        #region Public Members

        /// <summary>
        ///     Creates instance options for the specified type.
        /// </summary>
        /// <typeparam name="T">The type to create an instance of.</typeparam>
        /// <returns>Returns the new created create instance options.</returns>
        public static ICreateInstanceOptions<T> CreateInstanceOptions<T>() where T : class, new() => new CreateInstanceOptions<T>();

        /// <summary>
        ///     Creates an instance of the specified type without any special configuration.
        /// </summary>
        /// <typeparam name="T">The type to create an instance of.</typeparam>
        /// <returns>Returns the new created instance.</returns>
        public static T CreateInstance<T>() where T : class, new() => CreateInstanceOptions<T>()
            .Complete()
            .CreateInstance();

        /// <summary>
        ///     Creates an instance of the specified type based on the given options.
        /// </summary>
        /// <exception cref="ArgumentNullException">options can not be null.</exception>
        /// <typeparam name="T">The type to create an instance of.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <returns>Returns the new created instance.</returns>
        public static T CreateInstance<T>( this ICreateInstanceOptionsComplete<T> options ) where T : class
        {
            options.ThrowIfNull( nameof( options ) );

            //Create instance
            var rootMemberInformation = new MemberInformation
            {
                MemberType = typeof (T),
                MemberPath = String.Empty,
                MemberName = String.Empty
            };
            var instance = CreateRootMember( options, rootMemberInformation );
            rootMemberInformation.MemberObject = instance;

            //Set each member of the created instance.
            SetAllMembers( options, rootMemberInformation );

            return instance;
        }

        #endregion

        #region Private Members

        #region Reflection

        /// <summary>
        ///     Gets a <see cref="IMemberInformation" /> for each given <see cref="PropertyInfo" />.
        /// </summary>
        /// <param name="propertyInfos">The property informations.</param>
        /// <param name="parentMemberInformation">The parent of the given properties.</param>
        /// <returns>Returns the new created <see cref="IMemberInformation" />.</returns>
        private static IEnumerable<IMemberInformation> GetMemberInformation( this IEnumerable<PropertyInfo> propertyInfos, IMemberInformation parentMemberInformation )
            => propertyInfos.Select( x => x.ToMemberInformation( parentMemberInformation ) );

        #endregion

        #region Selection

        /// <summary>
        ///     Gets a value determining whether the member should be included or not.
        /// </summary>
        /// <exception cref="CreateInstanceException">No matching rule was found.</exception>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <param name="memberInformation">The member to check.</param>
        /// <returns>Returns a value of true if the member should be included; otherwise, false.</returns>
        private static Boolean IncludeMember<T>( ICreateInstanceOptionsComplete<T> options, IMemberInformation memberInformation )
            => ShouldMemberBeIncluded( memberInformation, options.MemberSelectionRules, DefaultMemberSelectionRules );

        /// <summary>
        ///     Gets a value determining whether the children should be included or not.
        /// </summary>
        /// <exception cref="CreateInstanceException">No matching rule was found.</exception>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <param name="memberInformation">The member to check.</param>
        /// <returns>Returns a value of true if the children should be included; otherwise, false.</returns>
        private static Boolean IncludeChildMembers<T>( ICreateInstanceOptionsComplete<T> options, IMemberInformation memberInformation )
            => ShouldMemberBeIncluded( memberInformation, options.MemberChildrenSelectionRules, DefaultMemberChildreSelectionRules );

        /// <summary>
        ///     Gets a value determining whether the member should be included or not.
        /// </summary>
        /// <exception cref="CreateInstanceException">No matching rule was found.</exception>
        /// <param name="memberInformation">The member to check.</param>
        /// <param name="selectionRuleSets">
        ///     A set of member selection rules.
        ///     Note: collections must be in correct order.
        /// </param>
        /// <returns>Returns a value of true if the member should be included; otherwise, false.</returns>
        private static Boolean ShouldMemberBeIncluded( IMemberInformation memberInformation, params IEnumerable<IMemberSelectionRule>[] selectionRuleSets )
        {
            //Try to find selection result (starting at the first item in selectionRuleSets)
            foreach ( var inspectionResult in selectionRuleSets
                .Select( ruleSet => RuleInspector.Inspect( ruleSet, memberInformation )
                                                 .AsBoolean() )
                .Where( inspectionResult => inspectionResult.HasValue ) )
                return inspectionResult.Value;

            //No matching rule found
            throw new CreateInstanceException( "Found no selection rule targeting member.",
                                               null,
                                               null,
                                               selectionRuleSets.SelectMany( x => x )
                                                                .StringJoin( Environment.NewLine ),
                                               memberInformation );
        }

        #endregion

        #region Creation

        /// <summary>
        ///     Gets the number of items to create for a collection.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <returns>Returns the number of items to create.</returns>
        private static Int32 GetCollectionItemCount<T>( ICreateInstanceOptionsComplete<T> options ) where T : class
        {
            //Return coubt od 0 if collection should net get populated
            if ( !PopulateCollection( options ) )
                return 0;

            var min = options.PopulateCollectionsMinCount ?? PopulateCollectionsMinCount;
            var max = options.PopulateCollectionsMaxCount ?? PopulateCollectionsMaxCount;

            return RandomValueEx.GetRandomInt32( min, max );
        }

        /// <summary>
        ///     Gets a value determining whether collections should get populated or not.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <returns>Returns a value of true if collections should get populated or not.</returns>
        private static Boolean PopulateCollection<T>( ICreateInstanceOptionsComplete<T> options ) where T : class => options.PopulateCollections ?? PopulateCollections;

        /// <summary>
        ///     Gets the name for anonymous items.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <returns>Returns the name to use.</returns>
        private static String GetAnonymousItemName<T>( ICreateInstanceOptionsComplete<T> options ) where T : class => options.AnonymousItemName ?? AnonymousItemName;

        /// <summary>
        ///     Creates the root instance.
        /// </summary>
        /// <exception cref="CreateInstanceException">Value creation failed.</exception>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <param name="memberInformation">The member to create.</param>
        /// <returns>Returns the created value.</returns>
        private static T CreateRootMember<T>( ICreateInstanceOptionsComplete<T> options, IMemberInformation memberInformation ) where T : class
        {
            try
            {
                var value = GetValue( options, memberInformation );
                return (T) value;
            }
            catch ( Exception ex )
            {
                throw new CreateInstanceException( $"Failed to create root object of type: {typeof (T).Name}.",
                                                   ex,
                                                   options.Factories.Concat( DefaultFactories )
                                                          .StringJoin( Environment.NewLine ),
                                                   null,
                                                   memberInformation );
            }
        }

        /// <summary>
        ///     Gets a value for the given member.
        /// </summary>
        /// <exception cref="CreateInstanceException">Value creation failed.</exception>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <param name="memberInformation">The member to check.</param>
        /// <returns>Returns the created value.</returns>
        private static Object GetValue<T>( ICreateInstanceOptionsComplete<T> options, IMemberInformation memberInformation ) where T : class
        {
            //Try get value from factory
            var factory = GetFactory( options, memberInformation );
            if ( factory != null )
                try
                {
                    return factory.CreateValue( memberInformation );
                }
                catch ( Exception ex )
                {
                    throw new CreateInstanceException( "Factory has thrown exception.", ex, factory.ToString(), null, memberInformation );
                }

            //Try create array value
            var value = TryCreateArrayValue( options, memberInformation );
            if ( value != null )
                return value;

            //Create value (first try IEnumerable than anything else)
            value = TryCreateIEnumerableValue( options, memberInformation ) ?? CreateValueUsingAcrivator( memberInformation );

            //Populate collection if collection (could be ICollection)
            return TryPopulateCollection( options, memberInformation, value );
        }

        /// <summary>
        ///     Tries to create an IEnumerable value for the given type.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <param name="memberInformation">The member to check.</param>
        /// <returns>Returns the created value, or null if the given type is not an array type (IEnumerable).</returns>
        private static Object TryCreateIEnumerableValue<T>( ICreateInstanceOptionsComplete<T> options, IMemberInformation memberInformation ) where T : class
        {
            //Check if member implements IEnumerable{T}
            if ( !memberInformation.MemberType.IsIEnumerableT() )
                return null;

            //Get a List{T} of the IEnumerable{T}'s item type as type
#if PORTABLE45

            var concreteType = typeof (List<>).MakeGenericType( memberInformation.MemberType.GenericTypeArguments );
#elif NET40
            var concreteType = typeof (List<>).MakeGenericType( memberInformation.MemberType.GetGenericArguments() );
#endif
            //Create an instance of the cunstructed type
            var instnace = Activator.CreateInstance( concreteType );

            //Update the type of the member in the member information
            var currentMember = memberInformation as MemberInformation;
            if ( currentMember != null )
                currentMember.MemberType = concreteType;
            memberInformation = currentMember;

            return instnace;
        }

        /// <summary>
        ///     Tries to create an array value for the given type.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <param name="memberInformation">The member to check.</param>
        /// <returns>Returns the created value, or null if the given type is not an array type.</returns>
        private static Object TryCreateArrayValue<T>( ICreateInstanceOptionsComplete<T> options, IMemberInformation memberInformation ) where T : class
        {
            //Check if member is an array type
            if ( !memberInformation.MemberType.IsArray )
                return null;

            //Create the array
            var elementType = memberInformation.MemberType.GetElementType();
            var array = Array.CreateInstance( elementType, GetCollectionItemCount( options ) );

            //Add items
            var anonymousItemName = GetAnonymousItemName( options );
            for ( var i = 0; i < array.Length; i++ )
            {
                var currentMember = new MemberInformation
                {
                    MemberType = elementType,
                    MemberPath = $"{memberInformation.MemberPath}.{anonymousItemName}",
                    MemberName = anonymousItemName
                };

                //Get the value of the current array item.
                var arrayItemValue = GetValue( options, currentMember );
                currentMember.MemberObject = arrayItemValue;
                SetAllMembers( options, currentMember );
                array.SetValue( arrayItemValue, i );
            }

            return array;
        }

        /// <summary>
        ///     Creates a value for the given member using <see cref="Activator" />.
        /// </summary>
        /// <exception cref="CreateInstanceException">Creation throw an exception.</exception>
        /// <param name="memberInformation">The member to check.</param>
        /// <returns>Returns the created value.</returns>
        private static Object CreateValueUsingAcrivator( IMemberInformation memberInformation )
        {
            try
            {
                //Create type using activator class
                return Activator.CreateInstance( memberInformation.MemberType );
            }
            catch ( Exception ex )
            {
                throw new CreateInstanceException( $"Failed to create an instance of the following type '{memberInformation.MemberType}' using Activator.",
                                                   ex,
                                                   null,
                                                   null,
                                                   memberInformation );
            }
        }

        /// <summary>
        ///     Gets the matching factory for the given member.
        /// </summary>
        /// <exception cref="CreateInstanceException">Multiple matching factories found.</exception>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <param name="memberInformation">The member to check.</param>
        /// <returns>Returns the matching factory, or null if no factory was found.</returns>
        private static IInstanceFactory GetFactory<T>( ICreateInstanceOptionsComplete<T> options, IMemberInformation memberInformation ) where T : class
        {
            //Get matching factory
            var factory = GetExactlymatchingFactory( options, memberInformation );
            if ( factory != null )
                return factory;

            //Try get inner type of nullable
            var nullableType = GetTypeFromNullable( memberInformation.MemberType );
            if ( nullableType == null )
                return null;

            //Update type
            var info = memberInformation as MemberInformation;
            if ( info != null )
                info.MemberType = nullableType;

            return GetExactlymatchingFactory( options, memberInformation );
        }

        /// <summary>
        ///     Gets the matching factory for the given member.
        /// </summary>
        /// <exception cref="CreateInstanceException">Multiple matching factories found.</exception>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <param name="memberInformation">The member to check.</param>
        /// <returns>Returns the matching factory, or null if no factory was found.</returns>
        private static IInstanceFactory GetExactlymatchingFactory<T>( ICreateInstanceOptionsComplete<T> options, IMemberInformation memberInformation ) where T : class
        {
            //Get factory from options
            var matchingFactories = options.Factories.Where( x => RuleInspector.Inspect( x.SelectionRules, memberInformation ) == MemberSelectionResult.IncludeMember )
                                           .ToList();
            if ( matchingFactories.Count == 1 )
                return matchingFactories.Single();

            //Check if multiple factories have matched
            if ( matchingFactories.Any() )
                throw new CreateInstanceException(
                    $"Found multiple matching factories for member (in options). Type is '{memberInformation.MemberType}'. Please make sure only one factory matches the member.",
                    null,
                    options.Factories.StringJoin( Environment.NewLine ),
                    null,
                    memberInformation );

            //Get factory from default factories
            matchingFactories = DefaultFactories.Where( x => RuleInspector.Inspect( x.SelectionRules, memberInformation ) == MemberSelectionResult.IncludeMember )
                                                .ToList();
            if ( matchingFactories.Count == 1 )
                return matchingFactories.Single();

            //Check if multiple factories have matched
            if ( matchingFactories.Any() )
                throw new CreateInstanceException(
                    $"Found multiple matching factories for member (in global configuration). Type is '{memberInformation.MemberType}'.  Please make sure only one factory matches the member.",
                    null,
                    DefaultFactories.StringJoin( Environment.NewLine ),
                    null,
                    memberInformation );

            //No factory found
            return null;
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

        /// <summary>
        ///     Populates the given instance if it is a collection, based on the collection configuration.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <param name="memberInformation">The member to check.</param>
        /// <param name="collectionInstance">The instance to populate.</param>
        /// <returns>Returns the populated or unmodified instance.</returns>
        private static Object TryPopulateCollection<T>( ICreateInstanceOptionsComplete<T> options, IMemberInformation memberInformation, Object collectionInstance ) where T : class
        {
            //Check if collection should get populated or not
            if ( !PopulateCollection( options ) || collectionInstance == null )
                return collectionInstance;

            //Check if type is collection type
            if ( !memberInformation.MemberType.ImplementsICollectionT() )
                return collectionInstance;

            //Get generic parameter type
            var genericArgumentType = memberInformation.MemberType.GetGenericTypeArgument();

            //Get the add method
#if PORTABLE45
            var addMethod = memberInformation.MemberType
                                             .GetRuntimeMethod( "Add", new[] { genericArgumentType } );
#elif NET40
            var addMethod = memberInformation.MemberType.GetMethod( "Add" );
#endif

            //Add items
            var anonymousItemName = GetAnonymousItemName( options );
            var collectionCount = GetCollectionItemCount( options );
            for ( var i = 0; i < collectionCount; i++ )
            {
                var currentMember = new MemberInformation
                {
                    MemberType = genericArgumentType,
                    MemberPath = $"{memberInformation.MemberPath}.{anonymousItemName}",
                    MemberName = anonymousItemName
                };

                //Get the value for the current collection item.
                var collectionItemValue = GetValue( options, currentMember );
                currentMember.MemberObject = collectionItemValue;
                SetAllMembers( options, currentMember );
                addMethod.Invoke( collectionInstance, new[] { collectionItemValue } );
            }
            return collectionInstance;
        }

        #endregion

        #region Set Value

        /// <summary>
        ///     Sets all members of the given member.
        /// </summary>
        /// <typeparam name="T">The type to create an instance of.</typeparam>
        /// <param name="options">Some create instance options.</param>
        /// <param name="memberInformation">The current member.</param>
        private static void SetAllMembers<T>( ICreateInstanceOptionsComplete<T> options, IMemberInformation memberInformation ) where T : class
        {
            //Check if children should be set or not
            if ( !IncludeChildMembers( options, memberInformation ) )
                return;

            //Get the properties of the current member as member information
            var propertyInfos = memberInformation.MemberType.GetPublicSettableProperties()
                                                 .GetMemberInformation( memberInformation );

            propertyInfos.ForEach( x =>
            {
                //Check if member should be set or not
                if ( !IncludeMember( options, x ) )
                    return;

                //Create member value
                var value = GetValue( options, x );
                x.PropertyInfo.SetValue( memberInformation.MemberObject, value, null );

                //Set children of value (recursive call)
                var currentMember = x as MemberInformation;
                if ( currentMember != null )
                    currentMember.MemberObject = value;

                SetAllMembers( options, currentMember );
            } );
        }

        #endregion

        #region Init

        /// <summary>
        ///     Creates the default factories.
        /// </summary>
        private static void CreateDefaultFactories() => InstanceFactoryProvider.GetDefaultFactories()
                                                                               .ForEach( x => DefaultFactories.Add( x ) );

        /// <summary>
        ///     Creates the default member selection rules.
        /// </summary>
        private static void CreateDefaultMemberSelectionRules() => MemberSelectionRuleProvider.GetDefaultMemberSelectionRules()
                                                                                              .ForEach( x => DefaultMemberSelectionRules.Add( x ) );

        /// <summary>
        ///     Creates the default member children selection rules.
        /// </summary>
        private static void CreateDefaultMemberChildreSelectionRules() => MemberSelectionRuleProvider.GetDefaultMemberChildreSelectionRules()
                                                                                                     .ForEach( x => DefaultMemberChildreSelectionRules.Add( x ) );

        #endregion

        #endregion
    }
}