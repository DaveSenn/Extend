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
        public void TryParsDecimalInvalidValueTest()
        {
            Decimal result;

            var actual = "InvalidValue".TryParsDecimal( out result );

            result
                .Should()
                .Be( default(Decimal) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsDecimalNullTest()
        {
            String value = null;
            Decimal result;

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDecimal( out result );

            result
                .Should()
                .Be( default(Decimal) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsDecimalOverloadFormatProviderNullTest()
        {
            CultureInfo culture = null;
            var expected = new Decimal( 100.123123 );
            Decimal result;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .TryParsDecimal( NumberStyles.Any, culture, out result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsDecimalOverloadInvalidNumberStyleTest()
        {
            var expected = new Decimal( 123.123 );
            Decimal result;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .TryParsDecimal( NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out result );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void TryParsDecimalOverloadInvalidValueTest()
        {
            Decimal result;

            var actual = "InvalidValue".TryParsDecimal( NumberStyles.Any, new CultureInfo( "de-CH" ), out result );

            result
                .Should()
                .Be( default(Decimal) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsDecimalOverloadNullTest()
        {
            String value = null;
            Decimal result;

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDecimal( NumberStyles.Any, new CultureInfo( "de-CH" ), out result );

            result
                .Should()
                .Be( default(Decimal) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsDecimalOverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var expected = new Decimal( 100.123123 );
            Decimal result;

            var actual = expected.ToString( culture )
                                 .TryParsDecimal( NumberStyles.Any, culture, out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Test]
        public void TryParsDecimalTest()
        {
            var expected = new Decimal( 100.123123 );
            Decimal result;

            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsDecimal( out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}