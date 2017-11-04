#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void ToDecimalFormatProviderNullTest()
        {
            var expected = new Decimal( 100.12 );
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDecimal( null );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToDecimalFormatProviderTest()
        {
            var expected = new Decimal( 100.12 );
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDecimal( CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToDecimalInvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal( CultureInfo.InvariantCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToDecimalInvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal();
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToDecimalInvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToDecimal( value, CultureInfo.InvariantCulture );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToDecimalInvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToDecimal( value );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToDecimalNullValueFormatProviderTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToDecimal( CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void ToDecimalNullValueTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToDecimal();

            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void ToDecimalTest()
        {
            var expected = new Decimal( 100.12 );
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDecimal();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToDecimalTooLargeFormatProviderTest()
        {
            // ReSharper disable once ImpureMethodCallOnReadonlyValueField
            var value = Decimal.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal( CultureInfo.InvariantCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToDecimalTooLargeTest()
        {
            // ReSharper disable once ImpureMethodCallOnReadonlyValueField
            var value = Decimal.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal();
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToDecimalTooSmallFormatProviderTest()
        {
            // ReSharper disable once ImpureMethodCallOnReadonlyValueField
            var value = Decimal.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal( CultureInfo.InvariantCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToDecimalTooSmallTest()
        {
            // ReSharper disable once ImpureMethodCallOnReadonlyValueField
            var value = Decimal.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal();
            test.ShouldThrow<OverflowException>();
        }
    }
}