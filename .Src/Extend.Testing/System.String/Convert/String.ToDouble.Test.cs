#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void ToDoubleInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "invalidFormat".ToDouble();

            Assert.Throws<FormatException>( test );
        }

        [Fact]
        public void ToDoubleNullTest()
        {
            String value = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => value.ToDouble();

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ToDoubleOverloadFormatNullTest()
        {
            CultureInfo formatProvider = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "1".ToDouble( formatProvider );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ToDoubleOverloadInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "invalidFormat".ToDouble( new CultureInfo( "de-CH" ) );

            Assert.Throws<FormatException>( test );
        }

        [Fact]
        public void ToDoubleOverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => value.ToDouble( new CultureInfo( "de-CH" ) );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ToDoubleOverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            const Double value = 122223.456;
            var actual = value.ToString( culture )
                              .ToDouble( culture );

            actual
                .Should()
                .Be( value );
        }

        [Fact]
        public void ToDoubleOverloadValueToBigTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "2.7976931348623157E+308".ToDouble( new CultureInfo( "de-CH" ) );

            Assert.Throws<OverflowException>( test );
        }

        [Fact]
        public void ToDoubleOverloadValueToSmallTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "-2.7976931348623157E+308".ToDouble( new CultureInfo( "de-CH" ) );

            Assert.Throws<OverflowException>( test );
        }

        [Fact]
        public void ToDoubleTest()
        {
            const Double value = 123.456;
            var actual = value.ToString( CultureInfo.CurrentCulture )
                              .ToDouble();

            actual
                .Should()
                .Be( value );
        }

        [Fact]
        public void ToDoubleValueToBigTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "2.7976931348623157E+308".ToDouble();

            Assert.Throws<OverflowException>( test );
        }

        [Fact]
        public void ToDoubleValueToSmallTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "-2.7976931348623157E+308".ToDouble();

            Assert.Throws<OverflowException>( test );
        }
    }
}

/*

        /// <summary>
        ///     Converts the given string to a double.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <exception cref="FormatException">value does not represent a number in a valid format.</exception>
        /// <exception cref="OverflowException">
        ///     value represents a number that is less than <see cref="Double.MinValue" /> or
        ///     greater than <see cref="Double.MaxValue" />.
        /// </exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>The double.</returns>
        [Pure]
        [PublicAPI]
        public static Double ToDouble( [NotNull] this String value, [NotNull] IFormatProvider formatProvider )
        {
            value.ThrowIfNull( nameof( value ) );
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return Double.Parse( value, formatProvider );
        }
*/