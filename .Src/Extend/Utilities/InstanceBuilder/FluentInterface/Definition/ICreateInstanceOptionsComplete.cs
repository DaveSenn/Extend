#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a complete create instance options object.
    /// </summary>
    /// <typeparam name="T">The type of the object to create.</typeparam>
    public interface ICreateInstanceOptionsComplete<T>
    {
        #region Properties

        /// <summary>
        ///     Gets all factories.
        /// </summary>
        /// <value>All factories.</value>
        List<IInstanceFactory> Factories { get; }

        /// <summary>
        ///     Gets all member-children selection rules.
        /// </summary>
        /// <value>All member-children selection rules.</value>
        List<IMemberSelectionRule> MemberChildrenSelectionRules { get; }

        /// <summary>
        ///     Gets all member selection rules.
        /// </summary>
        /// <value>All member selection rules.</value>
        List<IMemberSelectionRule> MemberSelectionRules { get; }

        /// <summary>
        ///     Gets a value determining whether collection members should be populated or not.
        /// </summary>
        /// <value>A value determining whether collection members should be populated or not.</value>
        Boolean? PopulateCollections { get; }

        /// <summary>
        ///     Gets the maximum number of items to create.
        /// </summary>
        /// <value>The maximum number of items to create.</value>
        Int32? PopulateCollectionsMaxCount { get; }

        /// <summary>
        ///     Gets the minimum number of items to create.
        /// </summary>
        /// <value>The minimum number of items to create.</value>
        Int32? PopulateCollectionsMinCount { get; }

        #endregion
    }
}