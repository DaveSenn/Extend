#region Usings

using System;
using System.Linq.Expressions;

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
        IIncludeExcludeOptions<T> AllMembers();

        /// <summary>
        ///     Matches for members which have a matching path.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can no the null.</exception>
        /// <param name="expression">Expression representing the member path.</param>
        /// <returns>Returns the modified options.</returns>
        IIncludeExcludeOptions<T> ByPath( Expression<Func<T, Object>> expression );

        /// <summary>
        ///     Matches for members which have a matching path.
        /// </summary>
        /// <exception cref="ArgumentNullException">path can no the null.</exception>
        /// <param name="path">The member path.</param>
        /// <returns>Returns the modified options.</returns>
        IIncludeExcludeOptions<T> ByPath( String path );

        /// <summary>
        ///     Matches for members which are NOT of the given type.
        /// </summary>
        /// <typeparam name="TTarget">The type to match.</typeparam>
        /// <returns>Returns the modified options.</returns>
        IIncludeExcludeOptions<T> IsNotTypeOf<TTarget>();

        /// <summary>
        ///     Matches for members which are of the given type.
        /// </summary>
        /// <typeparam name="TTarget">The type to match.</typeparam>
        /// <returns>Returns the modified options.</returns>
        IIncludeExcludeOptions<T> IsTypeOf<TTarget>();
    }
}