#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Base class for instance factories.
    /// </summary>
    public abstract class InstanceFactoryBase : IInstanceFactory
    {
        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="InstanceFactoryBase" /> class.
        /// </summary>
        /// <param name="name">The name of the factory.</param>
        /// <param name="description">The description of the factory.</param>
        protected InstanceFactoryBase( String name, String description )
        {
            FactoryName = name;
            FactoryDescription = description;
        }

        #endregion

        #region Overrides of Object

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override String ToString()
            => $"[{FactoryName}] = ({FactoryDescription}).";

        #endregion

        #region Implementation of IMemberSelectionRule

        /// <summary>
        ///     Adds the given <see cref="IMemberSelectionRule" /> to the factory.
        /// </summary>
        /// <exception cref="ArgumentNullException">memberSelectionRule can not be null.</exception>
        /// <param name="memberSelectionRule">The <see cref="IMemberSelectionRule" /> to add.</param>
        /// <returns>Returns the modified factory.</returns>
        public IInstanceFactory AddSelectionRule( IMemberSelectionRule memberSelectionRule )
        {
            memberSelectionRule.ThrowIfNull( nameof( memberSelectionRule ) );

            SelectionRules.Add( memberSelectionRule );
            return this;
        }

        /// <summary>
        ///     Gets the value for the given <see cref="IMemberInformation" />.
        /// </summary>
        /// <param name="memberInformation">Information about the member to create a value for.</param>
        /// <returns>Returns the created value.</returns>
        public abstract Object CreateValue( IMemberInformation memberInformation );

        /// <summary>
        ///     Gets the name of the factory.
        /// </summary>
        /// <value>The name of the factory.</value>
        public String FactoryName { get; }

        /// <summary>
        ///     Gets the description of the factory.
        /// </summary>
        /// <value>The description of the factory.</value>
        public String FactoryDescription { get; }

        /// <summary>
        ///     Gets the selection rules of the factory.
        /// </summary>
        /// <value>The selection rules of the factory.</value>
        public List<IMemberSelectionRule> SelectionRules { get; } = new List<IMemberSelectionRule>();

        #endregion
    }
}