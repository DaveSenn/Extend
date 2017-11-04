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
        public void SafeToInt32InvalidValueDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SafeToInt32( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt32InvalidValueTest()
        {
            var actual = "InvalidValue".SafeToInt32();

            actual
                .Should()
                .Be( default(Int32) );
        }

        [Fact]
        public void SafeToInt32NullDefaultTest()
        {
            String value = null;
            var expected = RandomValueEx.GetRandomInt32();
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToInt32( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt32NullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToInt32();

            actual
                .Should()
                .Be( default(Int32) );
        }

        [Fact]
        public void SafeToInt32OverloadFormatProviderNullTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "12".SafeToInt32( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SafeToInt32OverloadInvalidNumberStyleTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "12".SafeToInt32( NumberStyles.AllowDecimalPoint | NumberStyles.HexNumber, CultureInfo.CurrentCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SafeToInt32OverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SafeToInt32( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Int32) );
        }

        [Fact]
        public void SafeToInt32OverloadInvalidValueWithDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SafeToInt32( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt32OverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToInt32( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Int32) );
        }

        [Fact]
        public void SafeToInt32OverloadNullWithDefaultTest()
        {
            String value = null;
            var expected = RandomValueEx.GetRandomInt32();
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToInt32( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt32OverloadTest()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToInt32( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt32OverloadWitDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToInt32( NumberStyles.Any, CultureInfo.InvariantCulture, RandomValueEx.GetRandomInt32() );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt32Test()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToInt32();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt32WithDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToInt32( RandomValueEx.GetRandomInt32() );

            actual
                .Should()
                .Be( expected );
        }
    }
}