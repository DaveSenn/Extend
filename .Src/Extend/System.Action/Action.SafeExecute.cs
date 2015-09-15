#region Usings

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
        ///     Executes the given action insode of a try catch block and catches all exceptions.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecute( this Action action )
        {
            return action.SafeExecuteExcept();
        }

        /// <summary>
        ///     Executes the given action insode of a try catch block. Cataches exceptions of the given type.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecute<TException>( this Action action ) where TException : Exception
        {
            return action.SafeExecute( typeof (TException) );
        }

        /// <summary>
        ///     Executes the given action insode of a try catch block. Cataches exceptions of the given types.
        /// </summary>
        /// <typeparam name="TException1">The first exception type to catch.</typeparam>
        /// <typeparam name="TException2">The second exception type to catch.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecute<TException1, TException2>( this Action action )
            where TException1 : Exception
            where TException2 : Exception
        {
            return action.SafeExecute( typeof (TException1), typeof (TException2) );
        }

        /// <summary>
        ///     Executes the given action insode of a try catch block. Cataches exceptions of the given types.
        /// </summary>
        /// <typeparam name="TException1">The first exception type to catch.</typeparam>
        /// <typeparam name="TException2">The second exception type to catch.</typeparam>
        /// <typeparam name="TException3">The third exception type to catch.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecute<TException1, TException2, TException3>( this Action action )
            where TException1 : Exception
            where TException2 : Exception
            where TException3 : Exception
        {
            return action.SafeExecute( typeof (TException1), typeof (TException2), typeof (TException3) );
        }

        /// <summary>
        ///     Executes the given action insode of a try catch block. Cataches exceptions of the given types.
        /// </summary>
        /// <typeparam name="TException1">The first exception type to catch.</typeparam>
        /// <typeparam name="TException2">The second exception type to catch.</typeparam>
        /// <typeparam name="TException3">The third exception type to catch.</typeparam>
        /// <typeparam name="TException4">The fourth exception type to catch.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecute<TException1, TException2, TException3, TException4>( this Action action )
            where TException1 : Exception
            where TException2 : Exception
            where TException3 : Exception
            where TException4 : Exception
        {
            return
                action.SafeExecute( typeof (TException1), typeof (TException2), typeof (TException3), typeof (TException4) );
        }

        /// <summary>
        ///     Executes the given action insode of a try catch block. Cataches all exception types contained in the given list of
        ///     exception types.
        /// </summary>
        /// <exception cref="ArgumentNullException">action can not be null.</exception>
        /// <exception cref="ArgumentNullException">exceptionsToCatch can not be null.</exception>
        /// <param name="action">The action to execute.</param>
        /// <param name="exceptionsToCatch">A list of exception types to catch.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecute( this Action action, params Type[] exceptionsToCatch )
        {
            action.ThrowIfNull( nameof( action ) );
            exceptionsToCatch.ThrowIfNull( nameof( exceptionsToCatch ) );

            try
            {
                action();
                return true;
            }
            catch ( Exception ex )
            {
                if ( exceptionsToCatch.NotAny( x => x == ex.GetType() ) )
                    throw;
                return false;
            }
        }
    }
}