#region Using

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
        /// Executes the given action insode of a try catch block. Cataches all exception types contained in the given list of exception types.
        /// </summary>
        /// <exception cref="ArgumentNullException">action can not be null.</exception>
        /// <exception cref="ArgumentNullException">exceptionsToCatch can not be null.</exception>
        /// <param name="action">The action to execute.</param>
        /// <param name="exceptionsToCatch">A list of exception types to catch.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecute(this Action action, params Type[] exceptionsToCatch)
        {
            action.ThrowIfNull(() => action);
            exceptionsToCatch.ThrowIfNull(() => exceptionsToCatch);

            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                if (exceptionsToCatch.NotAny(x => x == ex.GetType()))
                    throw;
                return false;
            }
        }

        /// <summary>
        /// Executes the given action insode of a try catch block and catches all exceptions.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <returns>Returns true if the action was executed without an exception, otherwise false.</returns>
        public static Boolean SafeExecute(this Action action)
        {
            return action.SafeExecuteExcept(new Type[0]);
        }
    }
}