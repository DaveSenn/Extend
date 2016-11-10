using System;
using System.Collections.Generic;

namespace Extend
{
    /// <summary>
    ///     Value provider for looking up known values.
    /// </summary>
    internal class LookuptValueProvider : ValueProviderBase
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
        public LookuptValueProvider( IDictionary<String, Object> values )
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
            catch ( Exception ex )
            {
                // Check if value was present in the dictionary
                if ( ex is KeyNotFoundException )
                    throw new FormatException( $"Could not found value for expression: '{expression}'." );

                throw new FormatException( $"Invalid format, invalid formatted expression: '{expression}'", ex );
            }
        }

        #endregion
    }
}