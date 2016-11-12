#region Usings

using System;

#endregion

namespace Extend.Internal
{
    public class ObjectValueProvider : ValueProviderBase
    {
        #region Fields

        /// <summary>
        ///     The source object.
        /// </summary>
        private readonly Object _source;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObjectValueProvider" /> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">source can not be null.</exception>
        /// <param name="source">The source object.</param>
        public ObjectValueProvider( Object source )
        {
            source.ThrowIfNull( nameof( source ) );

            _source = source;
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
                var value = ExpressionEvaluator.GetValue( formatInformation.ValueName, _source );

                return formatInformation.Format.IsEmpty()
                    ? value?.ToString()
                    : formatInformation.Format.F( value );
            }
            catch ( Exception ex )
            {
                throw new FormatException( $"Invalid format, invalid formatted expression: '{expression}'", ex );
            }
        }

        #endregion
    }
}