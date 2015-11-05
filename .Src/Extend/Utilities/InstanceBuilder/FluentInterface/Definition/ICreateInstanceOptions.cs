#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a set of options used to create an instance of a type.
    /// </summary>
    /// <typeparam name="T">The type of the instance to create.</typeparam>
    public interface ICreateInstanceOptions<T> where T : class
    {
        /// <summary>
        ///     Ends the configuration and returns the configuration result.
        /// </summary>
        /// <returns>Returns the completely configured create instance options. </returns>
        ICreateInstanceOptionsComplete<T> Complete();

        /// <summary>
        ///     Excludes all members matching the specified options.
        /// </summary>
        /// <param name="configurationFunc">Function used to configuration the exclude.</param>
        /// <returns>Returns the modified create instance options.</returns>
        ICreateInstanceOptions<T> Excluding( Func<IIncludeExcludeOptions<T>, IIncludeExcludeOptions<T>> configurationFunc );

        /// <summary>
        ///     Excludes all members matching the given predicate.
        /// </summary>
        /// <param name="predicate">The predicate used to find the members to exclude.</param>
        /// <returns>Returns the modified create instance options.</returns>
        ICreateInstanceOptions<T> Excluding( Func<IMemberInformation, Boolean> predicate );

        /// <summary>
        ///     Excludes the children of all members matching the given predicate.
        ///     The members themselves will still get created.
        /// </summary>
        /// <param name="predicate">The predicate used to find the members to exclude.</param>
        /// <returns>Returns the modified create instance options.</returns>
        ICreateInstanceOptions<T> ExcludingChildrenOf( Func<IMemberInformation, Boolean> predicate );

        /// <summary>
        ///     Excludes the children of all members matching the specified options.
        ///     The members themselves will still get created.
        /// </summary>
        /// <param name="configurationFunc">Function used to configure the exclude.</param>
        /// <returns>Returns the modified create instance options.</returns>
        ICreateInstanceOptions<T> ExcludingChildrenOf( Func<IIncludeExcludeOptions<T>, IIncludeExcludeOptions<T>> configurationFunc );

        /// <summary>
        ///     Includes all members matching the specified options.
        /// </summary>
        /// <param name="configurationFunc">Function used to configuration the exclude.</param>
        /// <returns>Returns the modified create instance options.</returns>
        ICreateInstanceOptions<T> Including( Func<IIncludeExcludeOptions<T>, IIncludeExcludeOptions<T>> configurationFunc );

        /// <summary>
        ///     Includes all members matching the given predicate.
        /// </summary>
        /// <param name="predicate">The predicate used to find the members to include.</param>
        /// <returns>Returns the modified create instance options.</returns>
        ICreateInstanceOptions<T> Including( Func<IMemberInformation, Boolean> predicate );

        /// <summary>
        ///     Includes the children of all members matching the given predicate.
        /// </summary>
        /// <param name="predicate">The predicate used to find the members to include.</param>
        /// <returns>Returns the modified create instance options.</returns>
        ICreateInstanceOptions<T> IncludingChildrenOf( Func<IMemberInformation, Boolean> predicate );

        /// <summary>
        ///     Includes the children of all members matching the specified options.
        /// </summary>
        /// <param name="configurationFunc">Function used to configure the exclude.</param>
        /// <returns>Returns the modified create instance options.</returns>
        ICreateInstanceOptions<T> IncludingChildrenOf( Func<IIncludeExcludeOptions<T>, IIncludeExcludeOptions<T>> configurationFunc );

        /// <summary>
        ///     Configures the number of items to create for collection members.
        /// </summary>
        /// <exception cref="ArgumentException">Maximum is not greater than minimum.</exception>
        /// <param name="min">The minimum number of items to create.</param>
        /// <param name="max">The maximum number of items to create.</param>
        /// <returns>Returns the modified create instance options.</returns>
        ICreateInstanceOptions<T> PopulateCollectionItemCount( Int32? min, Int32? max );

        /// <summary>
        ///     Configures the creation of collection items.
        /// </summary>
        /// <param name="populateCollections">
        ///     A value determining whether items for collection types should be created or not. Null
        ///     means use default configuration.
        /// </param>
        /// <returns>Returns the modified create instance options.</returns>
        ICreateInstanceOptions<T> PopulateCollectionMembers( Boolean? populateCollections );

        /// <summary>
        ///     Configures the name of anonymous items.
        /// </summary>
        /// <param name="anonymousItemName">The name used for anonymouns items, or null to use global configuration.</param>
        /// <returns>Returns the modified create instance options.</returns>
        ICreateInstanceOptions<T> SetAnonymousItemName( String anonymousItemName );

        /// <summary>
        ///     Adds the given factory to the value providers.
        /// </summary>
        /// <exception cref="ArgumentNullException">factory can not be null.</exception>
        /// <param name="factory">The factory to add.</param>
        /// <returns>Returns the modified create instance options.</returns>
        IFactoryOptionsInconsistent<T> WithFactory( Func<IMemberInformation, Object> factory );
    }
}