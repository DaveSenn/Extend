#region Using

using System;

#endregion

namespace PortableExtensions
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
        /// <exception cref="ArgumentNullException">Action can not be null, if the value is true.</exception>
        /// <param name="value">The Boolean to check.</param>
        /// <param name="action">The action to execute if the given value is true.</param>
        /// <param name="alternativeAction">The action to execute if the given value is false.</param>
        /// <returns>Returns the given boolean value.</returns>
        public static Boolean IfTrue( this Boolean value, Action action, Action alternativeAction = null )
        {
            if ( value )
            {
                action.ThrowIfNull( () => action );
                action();
            }
            else if ( alternativeAction != null )
                alternativeAction();

            return value;
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean is true,
        ///     otherwise it executes the specified alternative action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">Action can not be null, if the value is true.</exception>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="value">The Boolean to check.</param>
        /// <param name="parameter">The parameter to pass to the action with gets executed.</param>
        /// <param name="action">The action to execute if the given value is true.</param>
        /// <param name="alternativeAction">The action to execute if the given value is false.</param>
        /// <returns>Returns the given boolean value.</returns>
        public static Boolean IfTrue<T>( this Boolean value,
                                         T parameter,
                                         Action<T> action,
                                         Action<T> alternativeAction = null )
        {
            if ( value )
            {
                action.ThrowIfNull( () => action );
                action( parameter );
            }
            else if ( alternativeAction != null )
                alternativeAction( parameter );

            return value;
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean is true,
        ///     otherwise it executes the specified alternative action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">Action can not be null, if the value is true.</exception>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="value">The Boolean to check.</param>
        /// <param name="parameter1">The first parameter to pass to the action with gets executed.</param>
        /// <param name="parameter2">The second parameter to pass to the action with gets executed.</param>
        /// <param name="action">The action to execute if the given value is true.</param>
        /// <param name="alternativeAction">The action to execute if the given value is false.</param>
        /// <returns>Returns the given boolean value.</returns>
        public static Boolean IfTrue<T1, T2>( this Boolean value,
                                              T1 parameter1,
                                              T2 parameter2,
                                              Action<T1, T2> action,
                                              Action<T1, T2> alternativeAction = null )
        {
            if ( value )
            {
                action.ThrowIfNull( () => action );
                action( parameter1, parameter2 );
            }
            else if ( alternativeAction != null )
                alternativeAction( parameter1, parameter2 );

            return value;
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean is true,
        ///     otherwise it executes the specified alternative action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">Action can not be null, if the value is true.</exception>
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
        public static Boolean IfTrue<T1, T2, T3>( this Boolean value,
                                                  T1 parameter1,
                                                  T2 parameter2,
                                                  T3 parameter3,
                                                  Action<T1, T2, T3> action,
                                                  Action<T1, T2, T3> alternativeAction = null )
        {
            if ( value )
            {
                action.ThrowIfNull( () => action );
                action( parameter1, parameter2, parameter3 );
            }
            else if ( alternativeAction != null )
                alternativeAction( parameter1, parameter2, parameter3 );

            return value;
        }

        /// <summary>
        ///     Executes the specified action if the given Boolean is true,
        ///     otherwise it executes the specified alternative action, if one is specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">Action can not be null, if the value is true.</exception>
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
        public static Boolean IfTrue<T1, T2, T3, T4>( this Boolean value,
                                                      T1 parameter1,
                                                      T2 parameter2,
                                                      T3 parameter3,
                                                      T4 parameter4,
                                                      Action<T1, T2, T3, T4> action,
                                                      Action<T1, T2, T3, T4> alternativeAction = null )
        {
            if ( value )
            {
                action.ThrowIfNull( () => action );
                action( parameter1, parameter2, parameter3, parameter4 );
            }
            else if ( alternativeAction != null )
                alternativeAction( parameter1, parameter2, parameter3, parameter4 );

            return value;
        }
    }
}