#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="bool" />.
    /// </summary>
    public static partial class BooleanEx
    {
        /// <summary>
        ///     Executes the specified action if the given Boolean is true,
        ///     otherwise it executes the specified alternative action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">action can not be null.</exception>
        /// <param name="value">The Boolean to check.</param>
        /// <param name="action">The action to execute if the given value is true.</param>
        /// <param name="alternativeAction">The action to execute if the given value is false.</param>
        /// <returns>Returns the given boolean value.</returns>
        [PublicAPI]
        [Pure]
        public static Boolean IfTrue( this Boolean value, [NotNull] Action action, [CanBeNull] Action alternativeAction = null )
        {
            action.ThrowIfNull( nameof(action) );

            if ( value )
                action();
            else
                alternativeAction?.Invoke();

            return value;
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean is true,
        ///     otherwise it executes the specified alternative action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">action can not be null.</exception>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="value">The Boolean to check.</param>
        /// <param name="parameter">The parameter to pass to the action with gets executed.</param>
        /// <param name="action">The action to execute if the given value is true.</param>
        /// <param name="alternativeAction">The action to execute if the given value is false.</param>
        /// <returns>Returns the given boolean value.</returns>
        [PublicAPI]
        [Pure]
        public static Boolean IfTrue<T>( this Boolean value,
                                         [CanBeNull] T parameter,
                                         [NotNull] Action<T> action,
                                         [CanBeNull] Action<T> alternativeAction = null )
        {
            action.ThrowIfNull( nameof(action) );

            if ( value )
                action( parameter );
            else
                alternativeAction?.Invoke( parameter );

            return value;
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean is true,
        ///     otherwise it executes the specified alternative action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">action can not be null.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="value">The Boolean to check.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="action">The action to execute if the given value is true.</param>
        /// <param name="alternativeAction">The action to execute if the given value is false.</param>
        /// <returns>Returns the given boolean value.</returns>
        [PublicAPI]
        [Pure]
        public static Boolean IfTrue<T1, T2>( this Boolean value,
                                              [CanBeNull] T1 parameter1,
                                              [CanBeNull] T2 parameter2,
                                              [NotNull] Action<T1, T2> action,
                                              [CanBeNull] Action<T1, T2> alternativeAction = null )
        {
            action.ThrowIfNull( nameof(action) );

            if ( value )
                action( parameter1, parameter2 );
            else
                alternativeAction?.Invoke( parameter1, parameter2 );

            return value;
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean is true,
        ///     otherwise it executes the specified alternative action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">action can not be null.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="value">The Boolean to check.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="parameter3">The third parameter to pass to the action with gets executed.</param>
        /// <param name="action">The action to execute if the given value is true.</param>
        /// <param name="alternativeAction">The action to execute if the given value is false.</param>
        /// <returns>Returns the given boolean value.</returns>
        [PublicAPI]
        [Pure]
        public static Boolean IfTrue<T1, T2, T3>( this Boolean value,
                                                  [CanBeNull] T1 parameter1,
                                                  [CanBeNull] T2 parameter2,
                                                  [CanBeNull] T3 parameter3,
                                                  [NotNull] Action<T1, T2, T3> action,
                                                  [CanBeNull] Action<T1, T2, T3> alternativeAction = null )
        {
            action.ThrowIfNull( nameof(action) );

            if ( value )
                action( parameter1, parameter2, parameter3 );
            else
                alternativeAction?.Invoke( parameter1, parameter2, parameter3 );

            return value;
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean is true,
        ///     otherwise it executes the specified alternative action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">action can not be null.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <param name="value">The Boolean to check.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="parameter3">The third parameter to pass to the action with gets executed.</param>
        /// <param name="parameter4">The fourth parameter to pass to the action with gets executed.</param>
        /// <param name="action">The action to execute if the given value is true.</param>
        /// <param name="alternativeAction">The action to execute if the given value is false.</param>
        /// <returns>Returns the given boolean value.</returns>
        [PublicAPI]
        [Pure]
        public static Boolean IfTrue<T1, T2, T3, T4>( this Boolean value,
                                                      [CanBeNull] T1 parameter1,
                                                      [CanBeNull] T2 parameter2,
                                                      [CanBeNull] T3 parameter3,
                                                      [CanBeNull] T4 parameter4,
                                                      [NotNull] Action<T1, T2, T3, T4> action,
                                                      [CanBeNull] Action<T1, T2, T3, T4> alternativeAction = null )
        {
            action.ThrowIfNull( nameof(action) );

            if ( value )
                action( parameter1, parameter2, parameter3, parameter4 );
            else
                alternativeAction?.Invoke( parameter1, parameter2, parameter3, parameter4 );

            return value;
        }
    }
}