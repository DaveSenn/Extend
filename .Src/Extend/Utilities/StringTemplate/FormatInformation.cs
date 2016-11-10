using System;

namespace Extend
{
    /// <summary>
    ///     Class representing information about a format.
    /// </summary>
    internal class FormatInformation
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the format.
        /// </summary>
        /// <value>The format.</value>
        public String Format { get; set; }

        /// <summary>
        ///     Gets or sets the name of the value/property.
        /// </summary>
        /// <value>The name of the value/property.</value>
        public String ValueName { get; set; }

        #endregion
    }
}