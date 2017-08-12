#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend.Internal
{
    /// <summary>
    ///     Class representing information about a format.
    /// </summary>
    public class FormatInformation
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the format.
        /// </summary>
        /// <value>The format.</value>
        public String Format { get; }

        /// <summary>
        ///     Gets or sets the name of the value/property.
        /// </summary>
        /// <value>The name of the value/property.</value>
        public String ValueName { get; }

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="FormatInformation" /> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">valueName can not be null.</exception>
        /// <param name="valueName">The name of the value.</param>
        /// <param name="format">The format.</param>
        public FormatInformation( [NotNull] String valueName, [CanBeNull] String format )
        {
            valueName.ThrowIfNull( nameof(valueName) );

            Format = format;
            ValueName = valueName;
        }

        #endregion
    }
}