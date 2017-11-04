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
        public void TryParsDoubleInvalidValueTest()
        {
            var actual = "InvalidValue".TryParsDouble( out var result );

            result
                .Should()
                .Be( default(Double) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDoubleNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDouble( out var result );

            result
                .Should()
                .Be( default(Double) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDoubleOverloadFormatProviderNullTest()
        {
            CultureInfo culture = null;
            const Double expected = 100.123d;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once UnusedVariable
                                        .TryParsDouble( NumberStyles.Any, culture, out var result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsDoubleOverloadInvalidNumberStyleTest()
        {
            CultureInfo culture = null;
            const Double expected = 100.123d;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once UnusedVariable
                                        .TryParsDouble( NumberStyles.AllowHexSpecifier, culture, out var result );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TryParsDoubleOverloadInvalidValueTest()
        {
            var actual = "InvalidValue".TryParsDouble( NumberStyles.Any, CultureInfo.InvariantCulture, out var result );

            result
                .Should()
                .Be( default(Double) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDoubleOverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDouble( NumberStyles.Any, CultureInfo.InvariantCulture, out var result );

            result
                .Should()
                .Be( default(Double) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDoubleOverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            const Double expected = 100.123d;
            var actual = expected.ToString( culture )
                                 .TryParsDouble( NumberStyles.Any, culture, out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Fact]
        public void TryParsDoubleTest()
        {
            const Double expected = 100.123d;
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .TryParsDouble( out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}