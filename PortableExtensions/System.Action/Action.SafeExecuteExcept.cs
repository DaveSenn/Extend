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
        ///     Executes the given action insed of a try catch block and catches all excepton expect the spcified type.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecuteExcept<TException>(this Action action)
        {
            return action.SafeExecuteExcept(new[] { typeof(TException) });
        }

        /// <summary>
        ///     Executes the given action insed of a try catch block and catches all excepton expect the given ones.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="exceptionsToThrow">The exceptions to throw.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecuteExcept(this Action action, params Type[] exceptionsToThrow)
        {
            action.ThrowIfNull(() => action);
            exceptionsToThrow.ThrowIfNull(() => exceptionsToThrow);

            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                if (exceptionsToThrow.Any(x => x == ex.GetType()))
                    throw;
                return false;
            }
        }

        /// <summary>
        ///     Executes the given action insed of a try catch block and catches all excepton expect the spcified typea.
        /// </summary>
        /// <typeparam name="TException1">The first exception type to throw.</typeparam>
        /// <typeparam name="TException2">The second exception type to throw.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecuteExcept<TException1, TException2>(this Action action)
        {
            return action.SafeExecuteExcept(new[] {typeof (TException1), typeof (TException2)});
        }

        /// <summary>
        ///     Executes the given action insed of a try catch block and catches all excepton expect the spcified typea.
        /// </summary>
        /// <typeparam name="TException1">The first exception type to throw.</typeparam>
        /// <typeparam name="TException2">The second exception type to throw.</typeparam>
        /// <typeparam name="TException3">The third exception type to throw.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecuteExcept<TException1, TException2, TException3>(this Action action)
        {
            return action.SafeExecuteExcept(new[] {typeof (TException1), typeof (TException2), typeof (TException3)});
        }

        /// <summary>
        ///     Executes the given action insed of a try catch block and catches all excepton expect the spcified typea.
        /// </summary>
        /// <typeparam name="TException1">The first exception type to throw.</typeparam>
        /// <typeparam name="TException2">The second exception type to throw.</typeparam>
        /// <typeparam name="TException3">The third exception type to throw.</typeparam>
        /// <typeparam name="TException4">The fourth exception type to throw.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecuteExcept<TException1, TException2, TException3, TException4>(this Action action)
        {
            return
                action.SafeExecuteExcept(new[]
                {typeof (TException1), typeof (TException2), typeof (TException3), typeof (TException4)});
        }
    }
}