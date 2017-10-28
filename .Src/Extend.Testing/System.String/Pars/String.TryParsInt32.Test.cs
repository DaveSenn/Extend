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
        public void TryParsInt32InvalidValueTest()
        {
            var actual = "InvalidValue".TryParsInt32( out var result );

            result
                .Should()
                .Be( default(Int32) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt32NullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsInt32( out var result );

            result
                .Should()
                .Be( default(Int32) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt32OverloadFormatProviderNullTest()
        {
            var expected = RandomValueEx.GetRandomInt32();
            CultureInfo culture = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once UnusedVariable
                                        .TryParsInt32( NumberStyles.Any, culture, out var result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsInt32OverloadInvalidNumberFormatTest()
        {
            var expected = RandomValueEx.GetRandomInt32();

            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once UnusedVariable
                                        .TryParsInt32( NumberStyles.AllowDecimalPoint | NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TryParsInt32OverloadInvalidValueTest()
        {
            var actual = "InvalidValue".TryParsInt32( NumberStyles.Any, new CultureInfo( "de-CH" ), out var result );

            result
                .Should()
                .Be( default(Int32) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt32OverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsInt32( NumberStyles.Any, new CultureInfo( "de-CH" ), out var result );

            result
                .Should()
                .Be( default(Int32) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt32OverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( culture )
                                 .TryParsInt32( NumberStyles.Any, culture, out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Fact]
        public void TryParsInt32Test()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .TryParsInt32( out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}