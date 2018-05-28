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
        public void ToInt64FormatProviderNullTest()
        {
            const Int64 expected = 666;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToInt64( null );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToInt64FormatProviderTest()
        {
            const Int64 expected = 666;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToInt64( CultureInfo.CurrentCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToInt64InvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt64( CultureInfo.CurrentCulture );
            Assert.Throws<InvalidCastException>( test );
        }

        [Fact]
        public void ToInt64InvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt64();
            Assert.Throws<InvalidCastException>( test );
        }

        [Fact]
        public void ToInt64InvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToInt64( value, CultureInfo.CurrentCulture );
            Assert.Throws<FormatException>( test );
        }

        [Fact]
        public void ToInt64InvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToInt64( value );
            Assert.Throws<FormatException>( test );
        }

        [Fact]
        public void ToInt64NullValueFormatProviderTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToInt64( CultureInfo.CurrentCulture );

            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void ToInt64NullValueTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToInt64();

            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void ToInt64Test()
        {
            const Int64 expected = 666;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToInt64();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToInt64TooLargeFormatProviderTest()
        {
            var value = Int64.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt64( CultureInfo.CurrentCulture );
            Assert.Throws<OverflowException>( test );
        }

        [Fact]
        public void ToInt64TooLargeTest()
        {
            var value = Int64.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt64();
            Assert.Throws<OverflowException>( test );
        }

        [Fact]
        public void ToInt64TooSmallFormatProviderTest()
        {
            var value = Int64.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt64( CultureInfo.CurrentCulture );
            Assert.Throws<OverflowException>( test );
        }

        [Fact]
        public void ToInt64TooSmallTest()
        {
            var value = Int64.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt64();
            Assert.Throws<OverflowException>( test );
        }
    }
}