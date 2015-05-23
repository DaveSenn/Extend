#region Usings

using System;
using System.Linq;

#endregion

namespace PortableExtensions
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
        /// <exception cref="ArgumentNullException">True action can not be null, if all values are true.</exception>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="falseAction">The action to execute if any of the given values is false.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfTrue( this Action trueAction, Action falseAction, params Boolean[] values )
        {
            if ( values.All( x => x ) )
            {
                trueAction.ThrowIfNull( () => trueAction );
                trueAction();
            }
            else if ( falseAction != null )
                falseAction();
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true,
        ///     otherwise it executes the specified false action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">True action can not be null, if all values are true.</exception>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter">The parameter to pass to the action with gets executed.</param>
        /// <param name="falseAction">The action to execute if any of the given values is false.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfTrue<T>( this Action<T> trueAction,
                                             T parameter,
                                             Action<T> falseAction,
                                             params Boolean[] values )
        {
            if ( values.All( x => x ) )
            {
                trueAction.ThrowIfNull( () => trueAction );
                trueAction( parameter );
            }
            else if ( falseAction != null )
                falseAction( parameter );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true,
        ///     otherwise it executes the specified false action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">True action can not be null, if all values are true.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="falseAction">The action to execute if any of the given values is false.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfTrue<T1, T2>( this Action<T1, T2> trueAction,
                                                  T1 parameter1,
                                                  T2 parameter2,
                                                  Action<T1, T2> falseAction,
                                                  params Boolean[] values )
        {
            if ( values.All( x => x ) )
            {
                trueAction.ThrowIfNull( () => trueAction );
                trueAction( parameter1, parameter2 );
            }
            else if ( falseAction != null )
                falseAction( parameter1, parameter2 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true,
        ///     otherwise it executes the specified false action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">True action can not be null, if all values are true.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="parameter3">The third parameter to pass to the action with gets executed.</param>
        /// <param name="falseAction">The action to execute if any of the given values is false.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfTrue<T1, T2, T3>( this Action<T1, T2, T3> trueAction,
                                                      T1 parameter1,
                                                      T2 parameter2,
                                                      T3 parameter3,
                                                      Action<T1, T2, T3> falseAction,
                                                      params Boolean[] values )
        {
            if ( values.All( x => x ) )
            {
                trueAction.ThrowIfNull( () => trueAction );
                trueAction( parameter1, parameter2, parameter3 );
            }
            else if ( falseAction != null )
                falseAction( parameter1, parameter2, parameter3 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true,
        ///     otherwise it executes the specified false action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">True action can not be null, if all values are true.</exception>
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
        public static void ExecuteIfTrue<T1, T2, T3, T4>( this Action<T1, T2, T3, T4> trueAction,
                                                          T1 parameter1,
                                                          T2 parameter2,
                                                          T3 parameter3,
                                                          T4 parameter4,
                                                          Action<T1, T2, T3, T4> falseAction,
                                                          params Boolean[] values )
        {
            if ( values.All( x => x ) )
            {
                trueAction.ThrowIfNull( () => trueAction );
                trueAction( parameter1, parameter2, parameter3, parameter4 );
            }
            else if ( falseAction != null )
                falseAction( parameter1, parameter2, parameter3, parameter4 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true.
        /// </summary>
        /// <exception cref="ArgumentNullException">True action can not be null, if all values are true.</exception>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfTrue( this Action trueAction, params Boolean[] values )
        {
            if ( !values.All( x => x ) )
                return;
            trueAction.ThrowIfNull( () => trueAction );

            trueAction();
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true.
        /// </summary>
        /// <exception cref="ArgumentNullException">True action can not be null, if all values are true.</exception>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter">The parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfTrue<T>( this Action<T> trueAction,
                                             T parameter,
                                             params Boolean[] values )
        {
            if ( !values.All( x => x ) )
                return;
            trueAction.ThrowIfNull( () => trueAction );

            trueAction( parameter );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true.
        /// </summary>
        /// <exception cref="ArgumentNullException">True action can not be null, if all values are true.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfTrue<T1, T2>( this Action<T1, T2> trueAction,
                                                  T1 parameter1,
                                                  T2 parameter2,
                                                  params Boolean[] values )
        {
            if ( !values.All( x => x ) )
                return;
            trueAction.ThrowIfNull( () => trueAction );

            trueAction( parameter1, parameter2 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true.
        /// </summary>
        /// <exception cref="ArgumentNullException">True action can not be null, if all values are true.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="trueAction">The action to execute if the given values are true.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="parameter3">The third parameter to pass to the action with gets executed.</param>
        /// <param name="values">The Boolean values to check.</param>
        public static void ExecuteIfTrue<T1, T2, T3>( this Action<T1, T2, T3> trueAction,
                                                      T1 parameter1,
                                                      T2 parameter2,
                                                      T3 parameter3,
                                                      params Boolean[] values )
        {
            if ( !values.All( x => x ) )
                return;
            trueAction.ThrowIfNull( () => trueAction );

            trueAction( parameter1, parameter2, parameter3 );
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean values are true.
        /// </summary>
        /// <exception cref="ArgumentNullException">True action can not be null, if all values are true.</exception>
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
        public static void ExecuteIfTrue<T1, T2, T3, T4>( this Action<T1, T2, T3, T4> trueAction,
                                                          T1 parameter1,
                                                          T2 parameter2,
                                                          T3 parameter3,
                                                          T4 parameter4,
                                                          params Boolean[] values )
        {
            if ( !values.All( x => x ) )
                return;
            trueAction.ThrowIfNull( () => trueAction );

            trueAction( parameter1, parameter2, parameter3, parameter4 );
        }
    }
}