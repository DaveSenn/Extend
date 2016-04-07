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
        public void TryParsDateTimeInvalidValueTest()
        {
            DateTime result;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = "InvalidValue".TryParsDateTime( out result );

            actual
                .Should()
                .BeFalse();

            result
                .Should()
                .Be( default(DateTime) );
        }

        [Test]
        public void TryParsDateTimeNullTest()
        {
            String value = null;
            DateTime result;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDateTime( out result );

            actual
                .Should()
                .BeFalse();

            result
                .Should()
                .Be( default(DateTime) );
        }

        [Test]
        public void TryParsDateTimeOverloadFormatProviderTest()
        {
            CultureInfo culture = null;
            var expected = DateTime.Now;
            DateTime result;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .TryParsDateTime( culture, DateTimeStyles.None, out result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsDateTimeOverloadInvalidValueTest()
        {
            DateTime result;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = "InvalidValue".TryParsDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, out result );

            actual
                .Should()
                .BeFalse();

            result
                .Should()
                .Be( default(DateTime) );
        }

        [Test]
        public void TryParsDateTimeOverloadNeutralFormatProviderTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var expected = DateTime.Now;
            DateTime result;

            Action test = () => expected.ToString( culture )
                                        .TryParsDateTime( culture, DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal, out result );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void TryParsDateTimeOverloadNullTest()
        {
            String value = null;
            DateTime result;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, out result );

            actual
                .Should()
                .BeFalse();

            result
                .Should()
                .Be( default(DateTime) );
        }

        [Test]
        public void TryParsDateTimeOverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var expected = DateTime.Now;
            DateTime result;
            var actual = expected.ToString( culture )
                                 .TryParsDateTime( culture, DateTimeStyles.None, out result );

            actual
                .Should()
                .BeTrue();

            result
                .Should()
                .BeCloseTo( expected, 999 );
        }

        [Test]
        public void TryParsDateTimeTest()
        {
            var expected = DateTime.Now;
            DateTime result;
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .TryParsDateTime( out result );

            actual
                .Should()
                .BeTrue();

            result
                .Should()
                .BeCloseTo( expected, 999 );
        }
    }
}