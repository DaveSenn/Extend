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
        public void TryParsInt16InvalidValueTest()
        {
            var actual = "InvalidValue".TryParsInt16( out var result );

            result
                .Should()
                .Be( default(Int16) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt16NullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsInt16( out var result );

            result
                .Should()
                .Be( default(Int16) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt16OverloadFormatProviderNullTest()
        {
            var expected = RandomValueEx.GetRandomInt16();
            CultureInfo culture = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once UnusedVariable
                                        .TryParsInt16( NumberStyles.Any, culture, out var result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsInt16OverloadInvalidNumberFormatTest()
        {
            var expected = RandomValueEx.GetRandomInt16();

            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once UnusedVariable
                                        .TryParsInt16( NumberStyles.AllowDecimalPoint | NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TryParsInt16OverloadInvalidValueTest()
        {
            var actual = "InvalidValue".TryParsInt16( NumberStyles.Any, new CultureInfo( "de-CH" ), out var result );

            result
                .Should()
                .Be( default(Int16) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt16OverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsInt16( NumberStyles.Any, new CultureInfo( "de-CH" ), out var result );

            result
                .Should()
                .Be( default(Int16) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt16OverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( culture )
                                 .TryParsInt16( NumberStyles.Any, culture, out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Fact]
        public void TryParsInt16Test()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .TryParsInt16( out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}