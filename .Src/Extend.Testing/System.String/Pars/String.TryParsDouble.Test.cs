#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void TryParsDoubleInvalidValueTest()
        {
            Double result;
            var actual = "InvalidValue".ToString( CultureInfo.CurrentCulture )
                                       .TryParsDouble( out result );

            result
                .Should()
                .Be( default(Double) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsDoubleNullTest()
        {
            String value = null;
            Double result;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDouble( out result );

            result
                .Should()
                .Be( default(Double) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
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

        [Test]
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

        [Test]
        public void TryParsDoubleOverloadInvalidValueTest()
        {
            Double result;
            var actual = "InvalidValue".ToString( CultureInfo.InvariantCulture )
                                       .TryParsDouble( NumberStyles.Any, CultureInfo.InvariantCulture, out result );

            result
                .Should()
                .Be( default(Double) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
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

        [Test]
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

        [Test]
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