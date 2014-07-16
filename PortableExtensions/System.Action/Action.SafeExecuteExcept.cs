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
        /// Executes the given action insed of a try catch block and catches all excepton expect the given ones.
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
    }
}