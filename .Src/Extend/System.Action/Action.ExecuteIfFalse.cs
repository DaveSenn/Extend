﻿#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Action" />.
    /// </summary>
    public static partial class ActionEx
    {
        /// <summary>
        ///     Executes the specified action if the given Boolean values are false,
        ///     otherwise it executes the specified true action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">False action can not be null, if all values are false.</exception>
        /// <param name="trueAction">The action to execute if any of the given values is true.</param>
        /// <param name="falseAction">The action to execute if the given values are false.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfFalse( this Action falseAction, Action trueAction, params Boolean[] values )
        {
            if ( values.NotAny( x => x ) )
            {
                falseAction.ThrowIfNull( nameof( falseAction ) );
                falseAction();
            }
            else
                trueAction?.Invoke();
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are false,
        ///     otherwise it executes the specified true action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">False action can not be null, if all values are false.</exception>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="trueAction">The action to execute if any of the given values is true.</param>
        /// <param name="falseAction">The action to execute if the given values are false.</param>
        /// <param name="parameter">The parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfFalse<T>( this Action<T> falseAction,
                                              T parameter,
                                              Action<T> trueAction,
                                              params Boolean[] values )
        {
            if ( values.NotAny( x => x ) )
            {
                falseAction.ThrowIfNull( nameof( falseAction ) );
                falseAction( parameter );
            }
            else
                trueAction?.Invoke( parameter );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are false,
        ///     otherwise it executes the specified true action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">False action can not be null, if all values are false.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="trueAction">The action to execute if any of the given values is true.</param>
        /// <param name="falseAction">The action to execute if the given values are false.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfFalse<T1, T2>( this Action<T1, T2> falseAction,
                                                   T1 parameter1,
                                                   T2 parameter2,
                                                   Action<T1, T2> trueAction,
                                                   params Boolean[] values )
        {
            if ( values.NotAny( x => x ) )
            {
                falseAction.ThrowIfNull( nameof( falseAction ) );
                falseAction( parameter1, parameter2 );
            }
            else
                trueAction?.Invoke( parameter1, parameter2 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are false,
        ///     otherwise it executes the specified true action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">False action can not be null, if all values are false.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="trueAction">The action to execute if any of the given values is true.</param>
        /// <param name="falseAction">The action to execute if the given values are false.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="parameter3">The third parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfFalse<T1, T2, T3>( this Action<T1, T2, T3> falseAction,
                                                       T1 parameter1,
                                                       T2 parameter2,
                                                       T3 parameter3,
                                                       Action<T1, T2, T3> trueAction,
                                                       params Boolean[] values )
        {
            if ( values.NotAny( x => x ) )
            {
                falseAction.ThrowIfNull( nameof( falseAction ) );
                falseAction( parameter1, parameter2, parameter3 );
            }
            else
                trueAction?.Invoke( parameter1, parameter2, parameter3 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are false,
        ///     otherwise it executes the specified true action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">False action can not be null, if all values are false.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <param name="trueAction">The action to execute if any of the given values is true.</param>
        /// <param name="falseAction">The action to execute if the given values are false.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="parameter3">The third parameter to pass to the action with gets executed.</param>
        /// <param name="parameter4">The fourth parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfFalse<T1, T2, T3, T4>( this Action<T1, T2, T3, T4> falseAction,
                                                           T1 parameter1,
                                                           T2 parameter2,
                                                           T3 parameter3,
                                                           T4 parameter4,
                                                           Action<T1, T2, T3, T4> trueAction,
                                                           params Boolean[] values )
        {
            if ( values.NotAny( x => x ) )
            {
                falseAction.ThrowIfNull( nameof( falseAction ) );
                falseAction( parameter1, parameter2, parameter3, parameter4 );
            }
            else
                trueAction?.Invoke( parameter1, parameter2, parameter3, parameter4 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are false.
        /// </summary>
        /// <exception cref="ArgumentNullException">False action can not be null, if all values are false.</exception>
        /// <param name="falseAction">The action to execute if the given values are false.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfFalse( this Action falseAction, params Boolean[] values )
        {
            if ( !values.NotAny( x => x ) )
                return;
            falseAction.ThrowIfNull( nameof( falseAction ) );

            falseAction();
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are false.
        /// </summary>
        /// <exception cref="ArgumentNullException">False action can not be null, if all values are false.</exception>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="falseAction">The action to execute if the given values are false.</param>
        /// <param name="parameter">The parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfFalse<T>( this Action<T> falseAction,
                                              T parameter,
                                              params Boolean[] values )
        {
            if ( !values.NotAny( x => x ) )
                return;

            falseAction.ThrowIfNull( nameof( falseAction ) );
            falseAction( parameter );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are false.
        /// </summary>
        /// <exception cref="ArgumentNullException">False action can not be null, if all values are false.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="falseAction">The action to execute if the given values are false.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfFalse<T1, T2>( this Action<T1, T2> falseAction,
                                                   T1 parameter1,
                                                   T2 parameter2,
                                                   params Boolean[] values )
        {
            if ( !values.NotAny( x => x ) )
                return;
            falseAction.ThrowIfNull( nameof( falseAction ) );

            falseAction( parameter1, parameter2 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are false.
        /// </summary>
        /// <exception cref="ArgumentNullException">False action can not be null, if all values are false.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="falseAction">The action to execute if the given values are false.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="parameter3">The third parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfFalse<T1, T2, T3>( this Action<T1, T2, T3> falseAction,
                                                       T1 parameter1,
                                                       T2 parameter2,
                                                       T3 parameter3,
                                                       params Boolean[] values )
        {
            if ( !values.NotAny( x => x ) )
                return;
            falseAction.ThrowIfNull( nameof( falseAction ) );

            falseAction( parameter1, parameter2, parameter3 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are false.
        /// </summary>
        /// <exception cref="ArgumentNullException">False action can not be null, if all values are false.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <param name="falseAction">The action to execute if the given values are false.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="parameter3">The third parameter to pass to the action with gets executed.</param>
        /// <param name="parameter4">The fourth parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfFalse<T1, T2, T3, T4>( this Action<T1, T2, T3, T4> falseAction,
                                                           T1 parameter1,
                                                           T2 parameter2,
                                                           T3 parameter3,
                                                           T4 parameter4,
                                                           params Boolean[] values )
        {
            if ( !values.NotAny( x => x ) )
                return;
            falseAction.ThrowIfNull( nameof( falseAction ) );

            falseAction( parameter1, parameter2, parameter3, parameter4 );
        }
    }
}