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
        public void ToDateTimeFormatProviderNullTest()
        {
            var expected = DateTime.Now;
            var value = expected.ToString( CultureInfo.CurrentCulture ) as Object;
            var actual = value.ToDateTime( null );

            actual
                .Should()
                .BeCloseTo( expected, 1000 );
        }

        [Fact]
        public void ToDateTimeFormatProviderTest()
        {
            var expected = DateTime.Now;
            var value = expected.ToString( CultureInfo.CurrentCulture ) as Object;
            var actual = value.ToDateTime( CultureInfo.CurrentCulture );

            actual
                .Should()
                .BeCloseTo( expected, 1000 );
        }

        [Fact]
        public void ToDateTimeInvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDateTime( CultureInfo.CurrentCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToDateTimeInvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDateTime();
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToDateTimeInvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToDateTime( value, CultureInfo.CurrentCulture );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToDateTimeInvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToDateTime( value );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToDateTimeNullValueFormatProviderTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToDateTime( CultureInfo.CurrentCulture );

            actual
                .Should()
                .Be( DateTime.MinValue );
        }

        [Fact]
        public void ToDateTimeNullValueTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToDateTime();

            actual
                .Should()
                .Be( DateTime.MinValue );
        }

        [Fact]
        public void ToDateTimeTest()
        {
            var expected = DateTime.Now;
            var value = expected.ToString( CultureInfo.CurrentCulture ) as Object;
            var actual = value.ToDateTime();

            actual
                .Should()
                .BeCloseTo( expected, 1000 );
        }
    }
}