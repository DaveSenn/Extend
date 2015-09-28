using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend
{
    /// <summary>
    ///     Interface representing an instance creator filter.
    /// </summary>
    public interface IInstanceCreatorFilter
    {
        #region Properties

        /// <summary>
        ///     Gets the name of the filter.
        /// </summary>
        /// <value>The name of the filter.</value>
        String Name { get; }

        /// <summary>
        ///     Gets the description of the filter.
        /// </summary>
        /// <value>The description of the filter.</value>
        String Description { get; }

        #endregion

        /// <summary>
        ///     Determines wheter the given arguments matches the condition or not.
        /// </summary>
        /// <param name="arguments">The arguments to check.</param>
        /// <returns>Returns a value of true if the arguments matches the condition; oterwise, false.</returns>
        Boolean Matches(IInstanceValueArguments arguments);
    }
}
