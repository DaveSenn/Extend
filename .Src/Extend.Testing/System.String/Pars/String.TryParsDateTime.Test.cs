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
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = "InvalidValue".TryParsDateTime( out var result );

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
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDateTime( out var result );

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

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once UnusedVariable
                                        .TryParsDateTime( culture, DateTimeStyles.None, out var result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsDateTimeOverloadInvalidValueTest()
        {
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = "InvalidValue".TryParsDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, out var result );

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

            Action test = () => expected.ToString( culture )
                                        // ReSharper disable once UnusedVariable
                                        .TryParsDateTime( culture, DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal, out var result );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TryParsDateTimeOverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, out var result );

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
            var actual = expected.ToString( culture )
                                 .TryParsDateTime( culture, DateTimeStyles.None, out var result );

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
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .TryParsDateTime( out var result );

            actual
                .Should()
                .BeTrue();

            result
                .Should()
                .BeCloseTo( expected, 999 );
        }
    }
}