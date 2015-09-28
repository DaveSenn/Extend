#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a instance value factory.
    /// </summary>
    public interface IInstanceValueFactory
    {
        #region Properties

        /// <summary>
        ///     Gets the conditions of the factory.
        /// </summary>
        /// <value>The conditions of the factory.</value>
        IInstanceBuilderConditionCollection Conditions { get; }
        
        /// <summary>
        ///     Gets the factory.
        /// </summary>
        /// <value>The factory.</value>
        Func<IInstanceValueArguments, Object> Factory { get; }

        #endregion

        /// <summary>
        ///     Determines wheter the factory matches the given arguments or not.
        /// </summary>
        /// <param name="arguments">The arguments to check against.</param>
        /// <returns>Returns a value of true if the factory matches the arguments; oterwise, false.</returns>
        Boolean Matches( IInstanceValueArguments arguments );
    }
}