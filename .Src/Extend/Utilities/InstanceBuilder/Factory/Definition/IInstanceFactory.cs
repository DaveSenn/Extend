#region Usings

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a value factory.
    /// </summary>
    public interface IInstanceFactory
    {
        #region Properties

        /// <summary>
        ///     Gets the name of the factory.
        /// </summary>
        /// <value>The name of the factory.</value>
        String FactoryName { get; }

        /// <summary>
        ///     Gets the description of the factory.
        /// </summary>
        /// <value>The description of the factory.</value>
        String FactoryDescription { get; }

        /// <summary>
        ///     Gets the selection rules of the factory.
        /// </summary>
        /// <value>The selection rules of the factory.</value>
        List<IMemberSelectionRule> SelectionRules { get; }

        #endregion

        /// <summary>
        ///     Adds the given <see cref="IMemberSelectionRule" /> to the factory.
        /// </summary>
        /// <exception cref="ArgumentNullException">memberSelectionRule can not be null.</exception>
        /// <param name="memberSelectionRule">The <see cref="IMemberSelectionRule" /> to add.</param>
        /// <returns>Returns the modified factory.</returns>
        [PublicAPI]
        [NotNull]
        IInstanceFactory AddSelectionRule( [NotNull] IMemberSelectionRule memberSelectionRule );

        /// <summary>
        ///     Gets the value for the given <see cref="IMemberInformation" />.
        /// </summary>
        /// <exception cref="ArgumentNullException">memberSelectionRule can not be null.</exception>
        /// <param name="memberInformation">Information about the member to create a value for.</param>
        /// <returns>Returns the created value.</returns>
        [PublicAPI]
        [CanBeNull]
        Object CreateValue( [NotNull] IMemberInformation memberInformation );
    }
}