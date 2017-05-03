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
            var actual = "InvalidValue".TryParsDouble( out Double result );

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
            var actual = value.TryParsDouble(out Double result);

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
            Double result;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .TryParsDouble( NumberStyles.Any, culture, out result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsDoubleOverloadInvalidNumberStyleTest()
        {
            CultureInfo culture = null;
            const Double expected = 100.123d;
            Double result;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .TryParsDouble( NumberStyles.AllowHexSpecifier, culture, out result );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TryParsDoubleOverloadInvalidValueTest()
        {
            Double result;
            var actual = "InvalidValue".TryParsDouble( NumberStyles.Any, CultureInfo.InvariantCulture, out result );

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
            Double result;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDouble( NumberStyles.Any, CultureInfo.InvariantCulture, out result );

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
            Double result;
            var actual = expected.ToString( culture )
                                 .TryParsDouble( NumberStyles.Any, culture, out result );

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
            Double result;
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .TryParsDouble( out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}