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
        public void TryParsDecimalInvalidValueTest()
        {
            var actual = "InvalidValue".TryParsDecimal( out var result );

            result
                .Should()
                .Be( default(Decimal) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDecimalNullTest()
        {
            String value = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDecimal( out var result );

            result
                .Should()
                .Be( default(Decimal) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDecimalOverloadFormatProviderNullTest()
        {
            CultureInfo culture = null;
            var expected = new Decimal( 100.123123 );

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once UnusedVariable
                                        .TryParsDecimal( NumberStyles.Any, culture, out var result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsDecimalOverloadInvalidNumberStyleTest()
        {
            var expected = new Decimal( 123.123 );

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once UnusedVariable
                                        .TryParsDecimal( NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out var result );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TryParsDecimalOverloadInvalidValueTest()
        {
            var actual = "InvalidValue".TryParsDecimal( NumberStyles.Any, new CultureInfo( "de-CH" ), out var result );

            result
                .Should()
                .Be( default(Decimal) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDecimalOverloadNullTest()
        {
            String value = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDecimal( NumberStyles.Any, new CultureInfo( "de-CH" ), out var result );

            result
                .Should()
                .Be( default(Decimal) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDecimalOverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var expected = new Decimal( 100.123123 );

            var actual = expected.ToString( culture )
                                 .TryParsDecimal( NumberStyles.Any, culture, out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Fact]
        public void TryParsDecimalTest()
        {
            var expected = new Decimal( 100.123123 );

            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsDecimal( out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}