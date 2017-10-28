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
        public void ToInt16FormatProviderNullTest()
        {
            const Int16 expected = 666;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToInt16( null );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToInt16FormatProviderTest()
        {
            const Int16 expected = 666;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToInt16( CultureInfo.CurrentCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToInt16InvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16( CultureInfo.CurrentCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToInt16InvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16();
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToInt16InvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToInt16( value, CultureInfo.CurrentCulture );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToInt16InvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToInt16( value );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToInt16NullValueFormatProviderTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToInt16( CultureInfo.CurrentCulture );

            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void ToInt16NullValueTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToInt16();

            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void ToInt16Test()
        {
            const Int16 expected = 666;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToInt16();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToInt16TooLargeFormatProviderTest()
        {
            var value = Int16.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16( CultureInfo.CurrentCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToInt16TooLargeTest()
        {
            var value = Int16.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16();
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToInt16TooSmallFormatProviderTest()
        {
            var value = Int16.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16( CultureInfo.CurrentCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToInt16TooSmallTest()
        {
            var value = Int16.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16();
            test.ShouldThrow<OverflowException>();
        }
    }
}