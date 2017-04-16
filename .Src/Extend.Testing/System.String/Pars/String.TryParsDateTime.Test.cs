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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
        public void TryParsDateTimeOverloadNeutralFormatProviderTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var expected = DateTime.Now;
            DateTime result;

            Action test = () => expected.ToString( culture )
                                        .TryParsDateTime( culture, DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal, out result );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
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

        [Fact]
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

        [Fact]
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