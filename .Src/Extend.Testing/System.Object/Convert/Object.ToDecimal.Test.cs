#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToDecimalFormatProviderNullTest()
        {
            var expected = new Decimal( 100.12 );
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDecimal( null );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToDecimalFormatProviderTest()
        {
            var expected = new Decimal( 100.12 );
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDecimal( CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToDecimalInvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal( CultureInfo.InvariantCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToDecimalInvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal();
            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToDecimalInvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToDecimal( value, CultureInfo.InvariantCulture );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToDecimalInvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToDecimal( value );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToDecimalNullValueFormatProviderTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToDecimal( CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( 0 );
        }

        [Test]
        public void ToDecimalNullValueTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToDecimal();

            actual
                .Should()
                .Be( 0 );
        }

        [Test]
        public void ToDecimalTest()
        {
            var expected = new Decimal( 100.12 );
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDecimal();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToDecimalTooLargeFormatProviderTest()
        {
            var value = Decimal.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal( CultureInfo.InvariantCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToDecimalTooLargeTest()
        {
            var value = Decimal.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal();
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToDecimalTooSmallFormatProviderTest()
        {
            var value = Decimal.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal( CultureInfo.InvariantCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToDecimalTooSmallTest()
        {
            var value = Decimal.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal();
            test.ShouldThrow<OverflowException>();
        }
    }
}