#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Executes the given action with the value as parameter and handles any exceptions during the execution.
        /// </summary>
        /// <exception cref="ArgumentNullException">The action can not be null.</exception>
        /// <param name="value">The value.</param>
        /// <param name="action">The action.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>Returns the given value as result or an exception if one is occurred.</returns>
        public static IExecutionResult<T> ExecuteSafe<T> ( this T value, Action<T> action )
        {
            action.ThrowIfNull( () => action );

            var result = new ExecutionResult<T>();
            try
            {
                action( value );
                result.Result = value;
            }
            catch ( Exception ex )
            {
                result.Exception = ex;
            }
            return result;
        }

        /// <summary>
        ///     Executes the given function with the value as parameter and handles any exceptions during the execution.
        /// </summary>
        /// <exception cref="ArgumentNullException">The func can not be null.</exception>
        /// <param name="value">The value.</param>
        /// <param name="func">The function.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <returns>Returns the result of the function or an exception if one is occurred.</returns>
        public static IExecutionResult<TResult> ExecuteSafe<T, TResult> ( this T value, Func<T, TResult> func )
        {
            func.ThrowIfNull( () => func );

            var result = new ExecutionResult<TResult>();
            try
            {
                result.Result = func( value );
            }
            catch ( Exception ex )
            {
                result.Exception = ex;
            }
            return result;
        }
    }
}