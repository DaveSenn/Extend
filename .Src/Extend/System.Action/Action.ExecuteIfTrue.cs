#region Usings

using System;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Action" />.
    /// </summary>
    public static partial class ActionEx
    {
        /// <summary>
        ///     Executes the specified action if the given Boolean values are true,
        ///     otherwise it executes the specified false action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">trueAction can not be null.</exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="falseAction">The action to execute if any of the given values is false.</param>
        /// <param name="values">The Boolean values to check.</param>
        [PublicAPI]
        public static void ExecuteIfTrue( [NotNull] this Action trueAction, [CanBeNull] Action falseAction, [NotNull] params Boolean[] values )
        {
            trueAction.ThrowIfNull( nameof(trueAction) );
            values.ThrowIfNull( nameof(values) );

            if ( values.All( x => x ) )
                trueAction();
            else
                falseAction?.Invoke();
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true,
        ///     otherwise it executes the specified false action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">trueAction can not be null.</exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter">The parameter to pass to the action with gets executed.</param>
        /// <param name="falseAction">The action to execute if any of the given values is false.</param>
        /// <param name="values">The Boolean values to check.</param>
        [PublicAPI]
        public static void ExecuteIfTrue<T>( [NotNull] this Action<T> trueAction,
                                             [CanBeNull] T parameter,
                                             [CanBeNull] Action<T> falseAction,
                                             [NotNull] params Boolean[] values )
        {
            trueAction.ThrowIfNull( nameof(trueAction) );
            values.ThrowIfNull( nameof(values) );

            if ( values.All( x => x ) )
                trueAction( parameter );
            else
                falseAction?.Invoke( parameter );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true,
        ///     otherwise it executes the specified false action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">trueAction can not be null.</exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="falseAction">The action to execute if any of the given values is false.</param>
        /// <param name="values">The Boolean values to check.</param>
        [PublicAPI]
        public static void ExecuteIfTrue<T1, T2>( [NotNull] this Action<T1, T2> trueAction,
                                                  [CanBeNull] T1 parameter1,
                                                  [CanBeNull] T2 parameter2,
                                                  [CanBeNull] Action<T1, T2> falseAction,
                                                  [NotNull] params Boolean[] values )
        {
            trueAction.ThrowIfNull( nameof(trueAction) );
            values.ThrowIfNull( nameof(values) );

            if ( values.All( x => x ) )
                trueAction( parameter1, parameter2 );
            else
                falseAction?.Invoke( parameter1, parameter2 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true,
        ///     otherwise it executes the specified false action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">trueAction can not be null.</exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="parameter3">The third parameter to pass to the action with gets executed.</param>
        /// <param name="falseAction">The action to execute if any of the given values is false.</param>
        /// <param name="values">The Boolean values to check.</param>
        [PublicAPI]
        public static void ExecuteIfTrue<T1, T2, T3>( [NotNull] this Action<T1, T2, T3> trueAction,
                                                      [CanBeNull] T1 parameter1,
                                                      [CanBeNull] T2 parameter2,
                                                      [CanBeNull] T3 parameter3,
                                                      [CanBeNull] Action<T1, T2, T3> falseAction,
                                                      [NotNull] params Boolean[] values )
        {
            trueAction.ThrowIfNull( nameof(trueAction) );
            values.ThrowIfNull( nameof(values) );

            if ( values.All( x => x ) )
                trueAction( parameter1, parameter2, parameter3 );
            else
                falseAction?.Invoke( parameter1, parameter2, parameter3 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true,
        ///     otherwise it executes the specified false action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">trueAction can not be null.</exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="parameter3">The third parameter to pass to the action with gets executed.</param>
        /// <param name="parameter4">The fourth parameter to pass to the action with gets executed.</param>
        /// <param name="falseAction">The action to execute if any of the given values is false.</param>
        /// <param name="values">The Boolean values to check.</param>
        [PublicAPI]
        public static void ExecuteIfTrue<T1, T2, T3, T4>( [NotNull] this Action<T1, T2, T3, T4> trueAction,
                                                          [CanBeNull] T1 parameter1,
                                                          [CanBeNull] T2 parameter2,
                                                          [CanBeNull] T3 parameter3,
                                                          [CanBeNull] T4 parameter4,
                                                          [CanBeNull] Action<T1, T2, T3, T4> falseAction,
                                                          [NotNull] params Boolean[] values )
        {
            trueAction.ThrowIfNull( nameof(trueAction) );
            values.ThrowIfNull( nameof(values) );

            if ( values.All( x => x ) )
                trueAction( parameter1, parameter2, parameter3, parameter4 );
            else
                falseAction?.Invoke( parameter1, parameter2, parameter3, parameter4 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true.
        /// </summary>
        /// <exception cref="ArgumentNullException">trueAction can not be null.</exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="values">The Boolean values to check.</param>
        [PublicAPI]
        public static void ExecuteIfTrue( [NotNull] this Action trueAction, [NotNull] params Boolean[] values )
        {
            trueAction.ThrowIfNull( nameof(trueAction) );
            values.ThrowIfNull( nameof(values) );

            if ( !values.All( x => x ) )
                return;

            trueAction();
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true.
        /// </summary>
        /// <exception cref="ArgumentNullException">trueAction can not be null.</exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter">The parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        [PublicAPI]
        public static void ExecuteIfTrue<T>( [NotNull] this Action<T> trueAction,
                                             [CanBeNull] T parameter,
                                             [NotNull] params Boolean[] values )
        {
            trueAction.ThrowIfNull( nameof(trueAction) );
            values.ThrowIfNull( nameof(values) );

            if ( !values.All( x => x ) )
                return;

            trueAction( parameter );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true.
        /// </summary>
        /// <exception cref="ArgumentNullException">trueAction can not be null.</exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        [PublicAPI]
        public static void ExecuteIfTrue<T1, T2>( [NotNull] this Action<T1, T2> trueAction,
                                                  [CanBeNull] T1 parameter1,
                                                  [CanBeNull] T2 parameter2,
                                                  [NotNull] params Boolean[] values )
        {
            trueAction.ThrowIfNull( nameof(trueAction) );
            values.ThrowIfNull( nameof(values) );

            if ( !values.All( x => x ) )
                return;

            trueAction( parameter1, parameter2 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true.
        /// </summary>
        /// <exception cref="ArgumentNullException">trueAction can not be null.</exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="parameter3">The third parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        [PublicAPI]
        public static void ExecuteIfTrue<T1, T2, T3>( [NotNull] this Action<T1, T2, T3> trueAction,
                                                      [CanBeNull] T1 parameter1,
                                                      [CanBeNull] T2 parameter2,
                                                      [CanBeNull] T3 parameter3,
                                                      [NotNull] params Boolean[] values )
        {
            trueAction.ThrowIfNull( nameof(trueAction) );
            values.ThrowIfNull( nameof(values) );

            if ( !values.All( x => x ) )
                return;

            trueAction( parameter1, parameter2, parameter3 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true.
        /// </summary>
        /// <exception cref="ArgumentNullException">trueAction can not be null.</exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="parameter3">The third parameter to pass to the action with gets executed.</param>
        /// <param name="parameter4">The fourth parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        [PublicAPI]
        public static void ExecuteIfTrue<T1, T2, T3, T4>( [NotNull] this Action<T1, T2, T3, T4> trueAction,
                                                          [CanBeNull] T1 parameter1,
                                                          [CanBeNull] T2 parameter2,
                                                          [CanBeNull] T3 parameter3,
                                                          [CanBeNull] T4 parameter4,
                                                          [NotNull] params Boolean[] values )
        {
            trueAction.ThrowIfNull( nameof(trueAction) );
            values.ThrowIfNull( nameof(values) );

            if ( !values.All( x => x ) )
                return;

            trueAction( parameter1, parameter2, parameter3, parameter4 );
        }
    }
}