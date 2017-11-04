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
        public void SafeToDecimalFormatProviderNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new Decimal( 1 ).ToString( CultureInfo.InvariantCulture )
                                                .SafeToDouble( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SafeToDecimalInvalidNumberStyleTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new Decimal( 1 ).ToString( CultureInfo.InvariantCulture )
                                                .SafeToDouble( NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SafeToDecimalInvalidValueTest()
        {
            var actual = "InvalidValue".SafeToDecimal();

            actual
                .Should()
                .Be( default(Decimal) );
        }

        [Fact]
        public void SafeToDecimalInvalidValueWithDefaultTest()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            var actual = "InvalidValue".SafeToDecimal( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDecimalNullTest()
        {
            String value = null;
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToDecimal( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDecimalOverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SafeToDecimal( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Decimal) );
        }

        [Fact]
        public void SafeToDecimalOverloadInvalidValueWithDefaultTest()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            var actual = "InvalidValue".SafeToDecimal( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDecimalOverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToDecimal( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Decimal) );
        }

        [Fact]
        public void SafeToDecimalOverloadTest()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToDecimal( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDecimalOverloadWithDefaultTest()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() + 0.1523 );
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToDecimal( NumberStyles.Any, CultureInfo.InvariantCulture, Decimal.MinValue );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDecimalTest()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToDecimal();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDecimalWithDefaultTest()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() + 0.123 );
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToDecimal( Decimal.MaxValue );

            actual
                .Should()
                .Be( expected );
        }
    }
}