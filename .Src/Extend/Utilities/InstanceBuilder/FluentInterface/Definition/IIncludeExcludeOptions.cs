#region Usings

using System;
using System.Linq.Expressions;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface exposing the include/exclude member options.
    /// </summary>
    /// <typeparam name="T">The type to exclude or include members of.</typeparam>
    public interface IIncludeExcludeOptions<T> where T : class
    {
        /// <summary>
        ///     Matches all members.
        /// </summary>
        /// <returns>Returns the modified options.</returns>
        [PublicAPI]
        [NotNull]
        IIncludeExcludeOptions<T> AllMembers();

        /// <summary>
        ///     Matches for members which have a matching path.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can no the null.</exception>
        /// <param name="expression">Expression representing the member path.</param>
        /// <returns>Returns the modified options.</returns>
        [PublicAPI]
        [NotNull]
        IIncludeExcludeOptions<T> ByPath( [NotNull] Expression<Func<T, Object>> expression );

        /// <summary>
        ///     Matches for members which have a matching path.
        /// </summary>
        /// <exception cref="ArgumentNullException">path can no the null.</exception>
        /// <param name="path">The member path.</param>
        /// <returns>Returns the modified options.</returns>
        [PublicAPI]
        [NotNull]
        IIncludeExcludeOptions<T> ByPath( [NotNull] String path );

        /// <summary>
        ///     Matches for members which are NOT of the given type.
        /// </summary>
        /// <typeparam name="TTarget">The type to match.</typeparam>
        /// <returns>Returns the modified options.</returns>
        [PublicAPI]
        [NotNull]
        IIncludeExcludeOptions<T> IsNotTypeOf<TTarget>();

        /// <summary>
        ///     Matches for members which are of the given type.
        /// </summary>
        /// <typeparam name="TTarget">The type to match.</typeparam>
        /// <returns>Returns the modified options.</returns>
        [PublicAPI]
        [NotNull]
        IIncludeExcludeOptions<T> IsTypeOf<TTarget>();
    }
}