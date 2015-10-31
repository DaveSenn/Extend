#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Factory for an instance value.
    /// </summary>
    public class InstanceValueFactory : IInstanceValueFactory
    {
        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="InstanceValueFactory" /> class.
        /// </summary>
        /// <param name="factory">The value factory.</param>
        public InstanceValueFactory( Func<IInstanceValueArguments, Object> factory )
        {
            Factory = factory;
        }

        #endregion

        #region Implementation of IInstanceValueFactory

        /// <summary>
        ///     Gets the conditions of the factory.
        /// </summary>
        /// z
        /// <value>The conditions of the factory.</value>
        public IInstanceBuilderConditionCollection Conditions { get; } = new InstanceBuilderConditionCollection();

        /// <summary>
        ///     Gets the factory.
        /// </summary>
        /// <value>The factory.</value>
        public Func<IInstanceValueArguments, Object> Factory { get; }

        /// <summary>
        ///     Determines wheter the factory matches the given arguments or not.
        /// </summary>
        /// <param name="arguments">The arguments to check against.</param>
        /// <returns>Returns a value of true if the factory matches the arguments; oterwise, false.</returns>
        public Boolean Matches( IInstanceValueArguments arguments )
        {
            return Conditions.Matches( arguments );
        }

        #endregion
    }
}