#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Expression based instance creator filter.
    /// </summary>
    public class ExpressionInstanceCreatorFilter : IInstanceCreatorFilter
    {
        #region Properties

        /// <summary>
        ///     Gets the predicate.
        /// </summary>
        /// <value>The predicate</value>
        private Func<IInstanceValueArguments, Boolean> Predicate { get; }

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionInstanceCreatorFilter" /> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">predicate can not be null.</exception>
        /// <param name="predicate">The predicate.</param>
        /// <param name="name">The name of the filter.</param>
        /// <param name="description">The description of the filter.</param>
        public ExpressionInstanceCreatorFilter( Func<IInstanceValueArguments, Boolean> predicate, String name, String description )
        {
            predicate.ThrowIfNull( nameof( predicate ) );

            Name = name;
            Description = description;
            Predicate = predicate;
        }

        #endregion

        #region Implementation of IInstanceCreatorFilter

        /// <summary>
        ///     Gets the name of the filter.
        /// </summary>
        /// <value>The name of the filter.</value>
        public String Name { get; }

        /// <summary>
        ///     Gets the description of the filter.
        /// </summary>
        /// <value>The description of the filter.</value>
        public String Description { get; }

        /// <summary>
        ///     Determines whether the given arguments matches the condition or not.
        /// </summary>
        /// <param name="arguments">The arguments to check.</param>
        /// <returns>Returns a value of true if the arguments matches the condition; otherwise, false.</returns>
        public Boolean Matches( IInstanceValueArguments arguments )
        {
            return Predicate( arguments );
        }

        #endregion
    }
}