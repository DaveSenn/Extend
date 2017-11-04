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
        public void SafeToInt16InvalidValueDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = "InvalidValue".SafeToInt16( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt16InvalidValueTest()
        {
            var actual = "InvalidValue".SafeToInt16();

            actual
                .Should()
                .Be( default(Int16) );
        }

        [Fact]
        public void SafeToInt16NullDefaultTest()
        {
            String value = null;
            var expected = RandomValueEx.GetRandomInt16();
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToInt16( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt16NullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToInt16();

            actual
                .Should()
                .Be( default(Int16) );
        }

        [Fact]
        public void SafeToInt16OverloadFormatProviderNullTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "12".SafeToInt16( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SafeToInt16OverloadInvalidNumberStyleTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "12".SafeToInt16( NumberStyles.AllowDecimalPoint | NumberStyles.HexNumber, CultureInfo.CurrentCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SafeToInt16OverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SafeToInt16( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Int16) );
        }

        [Fact]
        public void SafeToInt16OverloadInvalidValueWithDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = "InvalidValue".SafeToInt16( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt16OverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToInt16( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Int16) );
        }

        [Fact]
        public void SafeToInt16OverloadNullWithDefaultTest()
        {
            String value = null;
            var expected = RandomValueEx.GetRandomInt16();
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToInt16( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt16OverloadTest()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToInt16( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt16OverloadWitDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToInt16( NumberStyles.Any, CultureInfo.InvariantCulture, RandomValueEx.GetRandomInt16() );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt16Test()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToInt16();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToInt16WithDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToInt16( RandomValueEx.GetRandomInt16() );

            actual
                .Should()
                .Be( expected );
        }
    }
}