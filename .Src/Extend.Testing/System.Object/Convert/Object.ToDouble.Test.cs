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
        public void ToDoubleFormatProviderNullTest()
        {
            const Double expected = 100.12;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDouble( null );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToDoubleFormatProviderTest()
        {
            const Double expected = 100.12;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDouble( CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToDoubleInvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDouble( CultureInfo.InvariantCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToDoubleInvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDouble();
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToDoubleInvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToDouble( value, CultureInfo.InvariantCulture );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToDoubleInvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToDouble( value );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToDoubleNullValueFormatProviderTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToDouble( CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void ToDoubleNullValueTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToDouble();

            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void ToDoubleTest()
        {
            const Double expected = 100.12;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDouble();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToDoubleTooLargeFormatProviderTest()
        {
            var value = Double.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDouble( CultureInfo.InvariantCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToDoubleTooLargeTest()
        {
            var value = Double.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDouble();
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToDoubleTooSmallFormatProviderTest()
        {
            var value = Double.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDouble( CultureInfo.InvariantCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToDoubleTooSmallTest()
        {
            var value = Double.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDouble();
            test.ShouldThrow<OverflowException>();
        }
    }
}