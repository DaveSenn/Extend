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
        public void TryParsInt64InvalidValueTest()
        {
            var actual = "InvalidValue".TryParsInt64( out var result );

            result
                .Should()
                .Be( default(Int64) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt64NullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsInt64( out var result );

            result
                .Should()
                .Be( default(Int64) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt64OverloadFormatProviderNullTest()
        {
            var expected = RandomValueEx.GetRandomInt64();
            CultureInfo culture = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once UnusedVariable
                                        .TryParsInt64( NumberStyles.Any, culture, out var result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsInt64OverloadInvalidNumberFormatTest()
        {
            var expected = RandomValueEx.GetRandomInt64();

            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once UnusedVariable
                                        .TryParsInt64( NumberStyles.AllowDecimalPoint | NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TryParsInt64OverloadInvalidValueTest()
        {
            var actual = "InvalidValue".TryParsInt64( NumberStyles.Any, new CultureInfo( "de-CH" ), out var result );

            result
                .Should()
                .Be( default(Int64) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt64OverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsInt64( NumberStyles.Any, new CultureInfo( "de-CH" ), out var result );

            result
                .Should()
                .Be( default(Int64) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt64OverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( culture )
                                 .TryParsInt64( NumberStyles.Any, culture, out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Fact]
        public void TryParsInt64Test()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .TryParsInt64( out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}