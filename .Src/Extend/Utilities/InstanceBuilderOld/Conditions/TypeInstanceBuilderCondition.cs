#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Type based condition.
    /// </summary>
    public class TypeInstanceBuilderCondition : ITypeInstanceBuilderCondition
    {
        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="TypeInstanceBuilderCondition" /> class.
        /// </summary>
        /// <param name="type">The type to match.</param>
        public TypeInstanceBuilderCondition( Type type )
        {
            Type = type;
        }

        #endregion

        #region Implementation of IInstanceBuilderCondition

        /// <summary>
        ///     Gets the type to match.
        /// </summary>
        /// <value>The type to match.</value>
        public Type Type { get; }

        /// <summary>
        ///     Determines wheter the given arguments matches the condition or not.
        /// </summary>
        /// <param name="arguments">The arguments to check.</param>
        /// <returns>Returns a value of true if the arguments matches the condition; oterwise, false.</returns>
        public Boolean Matches( IInstanceValueArguments arguments )
        {
            arguments.ThrowIfNull( nameof( arguments ) );

            return arguments.PropertyType == Type;
        }

        #endregion
    }
}