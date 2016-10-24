#region Usings

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class representing the options for the create instance feature.
    /// </summary>
    /// <typeparam name="T">The type of the instance to create.</typeparam>
    public class CreateInstanceOptions<T> : ICreateInstanceOptionsComplete<T>,
        IIncludeExcludeOptions<T>,
        IFactoryOptionsConstistent<T> where T : class
    {
        #region Fields

        /// <summary>
        ///     Gets or sets the current factory.
        /// </summary>
        /// <value>The current factory.</value>
        private IInstanceFactory _currentFactory;

        /// <summary>
        ///     Gets or sets the current member selection mode (include or exclude).
        /// </summary>
        /// <value>The current member selection mode (include or exclude).</value>
        private MemberSelectionMode _currentMemberSelectionMode;

        /// <summary>
        ///     Gets the current member selection target (member or member-children).
        /// </summary>
        /// <value>The current member selection target (member or member-children).</value>
        private MemberSelectionRuleTarget _currentMemberSelectionTarget;

        #endregion

        #region Private Members

        /// <summary>
        ///     Adds the given member selection rule to the correct member selection collection.
        /// </summary>
        /// <param name="memberSelectionRule">The member selection rule to add.</param>
        /// <returns>Returns the current instance.</returns>
        private CreateInstanceOptions<T> AddMemberSlectionRule( IMemberSelectionRule memberSelectionRule )
        {
            switch ( _currentMemberSelectionTarget )
            {
                case MemberSelectionRuleTarget.Member:
                    MemberSelectionRules.Add( memberSelectionRule );
                    break;
                case MemberSelectionRuleTarget.MemberChildren:
                    MemberChildrenSelectionRules.Add( memberSelectionRule );
                    break;
                case MemberSelectionRuleTarget.Factory:
                    _currentFactory?.AddSelectionRule( memberSelectionRule );
                    break;
                default:
                    throw new ArgumentOutOfRangeException( nameof( _currentMemberSelectionTarget ),
                                                           _currentMemberSelectionTarget,
                                                           $"The member selection target '{_currentMemberSelectionTarget}' is not supported." );
            }

            return this;
        }

        #endregion

        #region Implementation of ICreateInstanceOptions<T>

        /// <summary>
        ///     Includes all members matching the specified options.
        /// </summary>
        /// <exception cref="ArgumentNullException">configurationFunc can not be null.</exception>
        /// <param name="configurationFunc">Function used to configure the exclude.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public ICreateInstanceOptions<T> Including( Func<IIncludeExcludeOptions<T>, IIncludeExcludeOptions<T>> configurationFunc )
        {
            configurationFunc.ThrowIfNull( nameof( configurationFunc ) );

            _currentMemberSelectionTarget = MemberSelectionRuleTarget.Member;
            _currentMemberSelectionMode = MemberSelectionMode.Include;
            configurationFunc( this );

            return this;
        }

        /// <summary>
        ///     Includes all members matching the given predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">predicate can not be null.</exception>
        /// <param name="predicate">The predicate used to find the members to include.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public ICreateInstanceOptions<T> Including( Func<IMemberInformation, Boolean> predicate )
        {
            predicate.ThrowIfNull( nameof( predicate ) );

            _currentMemberSelectionTarget = MemberSelectionRuleTarget.Member;
            return AddMemberSlectionRule( new ExpressionMemberSelectionRule( predicate, MemberSelectionMode.Include ) );
        }

        /// <summary>
        ///     Excludes all members matching the specified options.
        /// </summary>
        /// <exception cref="ArgumentNullException">configurationFunc can not be null.</exception>
        /// <param name="configurationFunc">Function used to configure the exclude.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public ICreateInstanceOptions<T> Excluding( Func<IIncludeExcludeOptions<T>, IIncludeExcludeOptions<T>> configurationFunc )
        {
            configurationFunc.ThrowIfNull( nameof( configurationFunc ) );

            _currentMemberSelectionTarget = MemberSelectionRuleTarget.Member;
            _currentMemberSelectionMode = MemberSelectionMode.Exclude;
            configurationFunc( this );

            return this;
        }

        /// <summary>
        ///     Excludes all members matching the given predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">predicate can not be null.</exception>
        /// <param name="predicate">The predicate used to find the members to exclude.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public ICreateInstanceOptions<T> Excluding( Func<IMemberInformation, Boolean> predicate )
        {
            predicate.ThrowIfNull( nameof( predicate ) );

            _currentMemberSelectionTarget = MemberSelectionRuleTarget.Member;
            return AddMemberSlectionRule( new ExpressionMemberSelectionRule( predicate, MemberSelectionMode.Exclude ) );
        }

        /// <summary>
        ///     Includes the children of all members matching the given predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">predicate can not be null.</exception>
        /// <param name="predicate">The predicate used to find the members to include.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public ICreateInstanceOptions<T> IncludingChildrenOf( Func<IMemberInformation, Boolean> predicate )
        {
            predicate.ThrowIfNull( nameof( predicate ) );

            _currentMemberSelectionTarget = MemberSelectionRuleTarget.MemberChildren;
            return AddMemberSlectionRule( new ExpressionMemberSelectionRule( predicate, MemberSelectionMode.Include ) );
        }

        /// <summary>
        ///     Includes the children of all members matching the specified options.
        /// </summary>
        /// <exception cref="ArgumentNullException">configurationFunc can not be null.</exception>
        /// <param name="configurationFunc">Function used to configure the exclude.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public ICreateInstanceOptions<T> IncludingChildrenOf( Func<IIncludeExcludeOptions<T>, IIncludeExcludeOptions<T>> configurationFunc )
        {
            configurationFunc.ThrowIfNull( nameof( configurationFunc ) );

            _currentMemberSelectionTarget = MemberSelectionRuleTarget.MemberChildren;
            _currentMemberSelectionMode = MemberSelectionMode.Include;
            configurationFunc( this );

            return this;
        }

        /// <summary>
        ///     Excludes the children of all members matching the specified options.
        ///     The members themselves will still get created.
        /// </summary>
        /// <exception cref="ArgumentNullException">configurationFunc can not be null.</exception>
        /// <param name="configurationFunc">Function used to configure the exclude.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public ICreateInstanceOptions<T> ExcludingChildrenOf( Func<IIncludeExcludeOptions<T>, IIncludeExcludeOptions<T>> configurationFunc )
        {
            configurationFunc.ThrowIfNull( nameof( configurationFunc ) );

            _currentMemberSelectionTarget = MemberSelectionRuleTarget.MemberChildren;
            _currentMemberSelectionMode = MemberSelectionMode.Exclude;
            configurationFunc( this );

            return this;
        }

        /// <summary>
        ///     Excludes the children of all members matching the given predicate.
        ///     The members themselves will still get created.
        /// </summary>
        /// <exception cref="ArgumentNullException">predicate can not be null.</exception>
        /// <param name="predicate">The predicate used to find the members to exclude.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public ICreateInstanceOptions<T> ExcludingChildrenOf( Func<IMemberInformation, Boolean> predicate )
        {
            predicate.ThrowIfNull( nameof( predicate ) );

            _currentMemberSelectionTarget = MemberSelectionRuleTarget.MemberChildren;
            return AddMemberSlectionRule( new ExpressionMemberSelectionRule( predicate, MemberSelectionMode.Exclude ) );
        }

        /// <summary>
        ///     Configures the number of items to create for collection members.
        /// </summary>
        /// <exception cref="ArgumentException">Maximum is not greater than minimum.</exception>
        /// <param name="min">The minimum number of items to create.</param>
        /// <param name="max">The maximum number of items to create.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public ICreateInstanceOptions<T> PopulateCollectionItemCount( Int32? min, Int32? max )
        {
            if ( min.HasValue && max.HasValue && min > max )
                throw new ArgumentException( "Maximum must be greater than the minimum count.", nameof( max ) );

            PopulateCollectionsMinCount = min;
            PopulateCollectionsMaxCount = max;

            return this;
        }

        /// <summary>
        ///     Configures the creation of collection items.
        /// </summary>
        /// <param name="populateCollections">
        ///     A value determining whether items for collection types should be created or not. Null
        ///     means use default configuration.
        /// </param>
        /// <returns>Returns the modified create instance options.</returns>
        public ICreateInstanceOptions<T> PopulateCollectionMembers( Boolean? populateCollections )
        {
            PopulateCollections = populateCollections;

            return this;
        }

        /// <summary>
        ///     Configures the name of anonymous items.
        /// </summary>
        /// <param name="anonymousItemName">The name used for anonymous items, or null to use global configuration.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public ICreateInstanceOptions<T> SetAnonymousItemName( String anonymousItemName )
        {
            AnonymousItemName = anonymousItemName;
            return this;
        }

        /// <summary>
        ///     Adds the given factory to the value providers.
        /// </summary>
        /// <exception cref="ArgumentNullException">factory can not be null.</exception>
        /// <param name="factory">The factory to add.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public IFactoryOptionsInconsistent<T> WithFactory( Func<IMemberInformation, Object> factory )
        {
            factory.ThrowIfNull( nameof( factory ) );

            // Create and add factory
            _currentFactory = new ExpressionInstanceFactory( factory );
            Factories.Add( _currentFactory );

            // Set target to factory
            _currentMemberSelectionTarget = MemberSelectionRuleTarget.Factory;

            return this;
        }

        /// <summary>
        ///     Ends the configuration and returns the configuration result.
        /// </summary>
        /// <returns>Returns the completely configured create instance options. </returns>
        public ICreateInstanceOptionsComplete<T> Complete()
            => this;

        #endregion

        #region Implementation of IIncludeExcludeOptions<T>

        /// <summary>
        ///     Adds a type based member selection rule.
        /// </summary>
        /// <typeparam name="TTarget">The type to match.</typeparam>
        /// <returns>Returns the modified options.</returns>
        public IIncludeExcludeOptions<T> IsTypeOf<TTarget>()
            => AddMemberSlectionRule( new TypeMemberSelectionRule( typeof(TTarget), _currentMemberSelectionMode, CompareMode.Is ) );

        /// <summary>
        ///     Matches for members which have a matching path.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can no the null.</exception>
        /// <param name="expression">Expression representing the member path.</param>
        /// <returns>Returns the modified options.</returns>
        public IIncludeExcludeOptions<T> ByPath( Expression<Func<T, Object>> expression )
        {
            expression.ThrowIfNull( nameof( expression ) );

            return AddMemberSlectionRule( new PathMemberSelectionRule( expression.GetMemberPath(), _currentMemberSelectionMode ) );
        }

        /// <summary>
        ///     Matches for members which have a matching path.
        /// </summary>
        /// <exception cref="ArgumentNullException">path can no the null.</exception>
        /// <param name="path">The member path.</param>
        /// <returns>Returns the modified options.</returns>
        public IIncludeExcludeOptions<T> ByPath( String path )
        {
            path.ThrowIfNull( nameof( path ) );

            return AddMemberSlectionRule( new PathMemberSelectionRule( path, _currentMemberSelectionMode ) );
        }

        /// <summary>
        ///     Adds a type based member selection rule.
        /// </summary>
        /// <typeparam name="TTarget">The type to match.</typeparam>
        /// <returns>Returns the modified options.</returns>
        public IIncludeExcludeOptions<T> IsNotTypeOf<TTarget>()
            => AddMemberSlectionRule( new TypeMemberSelectionRule( typeof(TTarget), _currentMemberSelectionMode, CompareMode.IsNot ) );

        /// <summary>
        ///     Matches all members.
        /// </summary>
        /// <returns>Returns the modified options.</returns>
        public IIncludeExcludeOptions<T> AllMembers()
            => AddMemberSlectionRule( new AllMemberSelectionRule( _currentMemberSelectionMode ) );

        #endregion

        #region Implementation of IFactoryOptionsInconsistent<T>

        /// <summary>
        ///     Factory will be used to create values for members matching the specified options.
        /// </summary>
        /// <exception cref="ArgumentNullException">configurationFunc can not be null.</exception>
        /// <param name="configurationFunc">Function used to configure the factory.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public IFactoryOptionsConstistent<T> For( Func<IIncludeExcludeOptions<T>, IIncludeExcludeOptions<T>> configurationFunc )
        {
            configurationFunc.ThrowIfNull( nameof( configurationFunc ) );

            //Check if target is factory.
            if ( _currentMemberSelectionTarget != MemberSelectionRuleTarget.Factory )
                throw new InvalidOperationException( "Cannot add rule to factory without specifying a factory first." );

            _currentMemberSelectionMode = MemberSelectionMode.Include;
            configurationFunc( this );

            return this;
        }

        /// <summary>
        ///     Factory will be used to create values for members matching the given predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">predicate can not be null.</exception>
        /// <param name="predicate">The predicate used to find the members which should get created by the factory.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public IFactoryOptionsConstistent<T> For( Func<IMemberInformation, Boolean> predicate )
        {
            predicate.ThrowIfNull( nameof( predicate ) );

            //Check if target is factory.
            if ( _currentMemberSelectionTarget != MemberSelectionRuleTarget.Factory )
                throw new InvalidOperationException( "Cannot add rule to factory without specifying a factory first." );

            return AddMemberSlectionRule( new ExpressionMemberSelectionRule( predicate, MemberSelectionMode.Include ) );
        }

        /// <summary>
        ///     Factory will NOT be used to create values for members matching the specified options.
        /// </summary>
        /// <exception cref="ArgumentNullException">configurationFunc can not be null.</exception>
        /// <param name="configurationFunc">Function used to configure the factory.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public IFactoryOptionsConstistent<T> NotFor( Func<IIncludeExcludeOptions<T>, IIncludeExcludeOptions<T>> configurationFunc )
        {
            configurationFunc.ThrowIfNull( nameof( configurationFunc ) );

            //Check if target is factory.
            if ( _currentMemberSelectionTarget != MemberSelectionRuleTarget.Factory )
                throw new InvalidOperationException( "Cannot add rule to factory without specifying a factory first." );

            _currentMemberSelectionMode = MemberSelectionMode.Exclude;
            configurationFunc( this );

            return this;
        }

        /// <summary>
        ///     Factory will NOT be used to create values for members matching the given predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">predicate can not be null.</exception>
        /// <param name="predicate">The predicate used to find the members which should NOT get created by the factory.</param>
        /// <returns>Returns the modified create instance options.</returns>
        public IFactoryOptionsConstistent<T> NotFor( Func<IMemberInformation, Boolean> predicate )
        {
            predicate.ThrowIfNull( nameof( predicate ) );

            //Check if target is factory.
            if ( _currentMemberSelectionTarget != MemberSelectionRuleTarget.Factory )
                throw new InvalidOperationException( "Cannot add rule to factory without specifying a factory first." );

            return AddMemberSlectionRule( new ExpressionMemberSelectionRule( predicate, MemberSelectionMode.Exclude ) );
        }

        #endregion

        #region Implementation of ICreateInstanceOptionsComplete<T>

        /// <summary>
        ///     Gets all factories.
        /// </summary>
        /// <value>All factories.</value>
        public List<IInstanceFactory> Factories { get; } = new List<IInstanceFactory>();

        /// <summary>
        ///     Gets all member-children selection rules.
        /// </summary>
        /// <value>All member-children selection rules.</value>
        public List<IMemberSelectionRule> MemberChildrenSelectionRules { get; } = new List<IMemberSelectionRule>();

        /// <summary>
        ///     Gets all member selection rules.
        /// </summary>
        /// <value>All member selection rules.</value>
        public List<IMemberSelectionRule> MemberSelectionRules { get; } = new List<IMemberSelectionRule>();

        /// <summary>
        ///     Gets a value determining whether collection members should be populated or not.
        /// </summary>
        /// <value>A value determining whether collection members should be populated or not.</value>
        public Boolean? PopulateCollections { get; private set; }

        /// <summary>
        ///     Gets the maximum number of items to create.
        /// </summary>
        /// <value>The maximum number of items to create.</value>
        public Int32? PopulateCollectionsMaxCount { get; private set; }

        /// <summary>
        ///     Gets the minimum number of items to create.
        /// </summary>
        /// <value>The minimum number of items to create.</value>
        public Int32? PopulateCollectionsMinCount { get; private set; }

        /// <summary>
        ///     Gets the name to use for anonymous items.
        /// </summary>
        /// <value>The name to use for anonymous items.</value>
        public String AnonymousItemName { get; private set; }

        #endregion
    }
}