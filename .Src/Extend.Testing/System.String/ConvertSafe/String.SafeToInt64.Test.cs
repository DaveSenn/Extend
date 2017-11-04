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
        public void SafeToInt64InvalidValueDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = "InvalidValue".SafeToInt64( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt64InvalidValueTest()
        {
            var actual = "InvalidValue".SafeToInt64();

            actual
                .Should()
                .Be( default(Int64) );
        }

        [Fact]
        public void SafeToInt64NullDefaultTest()
        {
            String value = null;
            var expected = RandomValueEx.GetRandomInt64();
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToInt64( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt64NullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToInt64();

            actual
                .Should()
                .Be( default(Int64) );
        }

        [Fact]
        public void SafeToInt64OverloadFormatProviderNullTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "12".SafeToInt64( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SafeToInt64OverloadInvalidNumberStyleTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "12".SafeToInt64( NumberStyles.AllowDecimalPoint | NumberStyles.HexNumber, CultureInfo.CurrentCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SafeToInt64OverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SafeToInt64( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Int64) );
        }

        [Fact]
        public void SafeToInt64OverloadInvalidValueWithDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = "InvalidValue".SafeToInt64( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt64OverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToInt64( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Int64) );
        }

        [Fact]
        public void SafeToInt64OverloadNullWithDefaultTest()
        {
            String value = null;
            var expected = RandomValueEx.GetRandomInt64();
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToInt64( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt64OverloadTest()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToInt64( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt64OverloadWitDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToInt64( NumberStyles.Any, CultureInfo.InvariantCulture, RandomValueEx.GetRandomInt64() );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt64Test()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToInt64();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt64WithDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToInt64( RandomValueEx.GetRandomInt64() );

            actual
                .Should()
                .Be( expected );
        }
    }
}