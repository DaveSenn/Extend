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
        public void ToInt32FormatProviderNullTest()
        {
            const Int32 expected = 666;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToInt32( null );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToInt32FormatProviderTest()
        {
            const Int32 expected = 666;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToInt32( CultureInfo.CurrentCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToInt32InvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt32( CultureInfo.CurrentCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToInt32InvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt32();
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToInt32InvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToInt32( value, CultureInfo.CurrentCulture );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToInt32InvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToInt32( value );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToInt32NullValueFormatProviderTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToInt32( CultureInfo.CurrentCulture );

            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void ToInt32NullValueTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToInt32();

            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void ToInt32Test()
        {
            const Int32 expected = 666;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToInt32();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToInt32TooLargeFormatProviderTest()
        {
            var value = Int32.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt32( CultureInfo.CurrentCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToInt32TooLargeTest()
        {
            var value = Int32.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt32();
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToInt32TooSmallFormatProviderTest()
        {
            var value = Int32.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt32( CultureInfo.CurrentCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToInt32TooSmallTest()
        {
            var value = Int32.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt32();
            test.ShouldThrow<OverflowException>();
        }
    }
}