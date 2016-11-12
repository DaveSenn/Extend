#region Usings

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Extend.Internal
{
    /// <summary>
    ///     Value provider for looking up known values.
    /// </summary>
    public class LookuptValueProvider : ValueProviderBase
    {
        #region Fields

        /// <summary>
        ///     The values.
        /// </summary>
        private readonly IDictionary<String, Object> _values;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="LookuptValueProvider" /> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <param name="values">The value to use.</param>
        public LookuptValueProvider( [NotNull] IDictionary<String, Object> values )
        {
            values.ThrowIfNull( nameof( values ) );

            _values = values;
        }

        #endregion

        #region Implementation of IValueProvider

        /// <summary>
        ///     Gets the value represented by the given expression.
        /// </summary>
        /// <param name="expression">The name of a property optionally combined with a string format compatible expression.</param>
        /// <returns>Returns the value represented by the given expression.</returns>
        public override String GetValue( String expression )
        {
            try
            {
                var formatInformation = ParsExpression( expression );
                return formatInformation.Format.IsEmpty()
                    ? _values[formatInformation.ValueName]?.ToString()
                    : formatInformation.Format.F( _values[formatInformation.ValueName] );
            }
            catch ( KeyNotFoundException ex )
            {
                throw new FormatException( $"Could not found value for expression: '{expression}'.", ex );
            }
        }

        #endregion
    }
}