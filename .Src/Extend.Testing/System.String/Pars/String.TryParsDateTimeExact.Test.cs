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
        public void TryParsDateTimeExactFormatNullTest()
        {
            const String dateString = "5/01/2009 09:00";

            String format = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => dateString.TryParsDateTimeExact( format,
                                                                 new CultureInfo( "en-US" ),
                                                                 DateTimeStyles.None,
                                                                 // ReSharper disable once UnusedVariable
                                                                 out var result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsDateTimeExactFormatProviderNullTest()
        {
            const String dateString = "5/01/2009 09:00";

            CultureInfo culture = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => dateString.TryParsDateTimeExact( "M/dd/ hh:mm yyyy",
                                                                 culture,
                                                                 DateTimeStyles.None,
                                                                 // ReSharper disable once UnusedVariable
                                                                 out var result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsDateTimeExactInvalidDateTimeStyleTest()
        {
            const String dateString = "5/01/2009 09:00";

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => dateString.TryParsDateTimeExact( "M/dd/ hh:mm yyyy",
                                                                 new CultureInfo( "den-US" ),
                                                                 DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal,
                                                                 // ReSharper disable once UnusedVariable
                                                                 out var result );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TryParsDateTimeExactInvalidFormatTest()
        {
            const String dateString = "5/01/ 09:00 2009";

            var actual = dateString.TryParsDateTimeExact( "asdasd",
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out var result );

            result
                .Should()
                .Be( default(DateTime) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDateTimeExactInvalidValueTest()
        {
            const String dateString = "asdasd";

            var actual = dateString.TryParsDateTimeExact( "M/dd/yyyy hh:mm",
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out var result );

            result
                .Should()
                .Be( default(DateTime) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDateTimeExactNullValueTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDateTimeExact( "M/dd/yyyy hh:mm",
                                                     new CultureInfo( "en-US" ),
                                                     DateTimeStyles.None,
                                                     out var result );

            result
                .Should()
                .Be( default(DateTime) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDateTimeExactOverloadFormatNullTest()
        {
            const String dateString = "5/01/2009 09:00";

            String[] formats = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => dateString.TryParsDateTimeExact( formats,
                                                                 new CultureInfo( "en-US" ),
                                                                 DateTimeStyles.None,
                                                                 // ReSharper disable once UnusedVariable
                                                                 out var result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsDateTimeExactOverloadFormatProviderNullTest()
        {
            const String dateString = "5/01/2009 09:00";

            CultureInfo culture = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => dateString.TryParsDateTimeExact( new[] { "asd", "M/dd/ hh:mm yyyy" },
                                                                 culture,
                                                                 DateTimeStyles.None,
                                                                 // ReSharper disable once UnusedVariable
                                                                 out var result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsDateTimeExactOverloadInvalidDateTimeStyleTest()
        {
            const String dateString = "5/01/2009 09:00";

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => dateString.TryParsDateTimeExact( new[] { "asd", "M/dd/ hh:mm yyyy" },
                                                                 new CultureInfo( "den-US" ),
                                                                 DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal,
                                                                 // ReSharper disable once UnusedVariable
                                                                 out var result );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TryParsDateTimeExactOverloadInvalidFormatTest()
        {
            const String dateString = "5/01/ 09:00 2009";

            var actual = dateString.TryParsDateTimeExact( new[] { "asdasd", "123" },
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out var result );

            result
                .Should()
                .Be( default(DateTime) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDateTimeExactOverloadInvalidValueTest()
        {
            const String dateString = "asdasd";

            var actual = dateString.TryParsDateTimeExact( new[] { "asdasd", "123" },
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out var result );

            result
                .Should()
                .Be( default(DateTime) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDateTimeExactOverloadNullValueTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDateTimeExact( new[] { "asdasd", "123" },
                                                     new CultureInfo( "en-US" ),
                                                     DateTimeStyles.None,
                                                     out var result );

            result
                .Should()
                .Be( default(DateTime) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsDateTimeExactOverloadTest()
        {
            var expected = new DateTime( 2009, 5, 1, 9, 0, 0 );
            const String dateString = "5/01/2009 09:00";

            var actual = dateString.TryParsDateTimeExact( new[] { "asd", "M/dd/yyyy hh:mm" },
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Fact]
        public void TryParsDateTimeExactOverloadTest1()
        {
            var expected = new DateTime( 2009, 5, 1, 9, 0, 0 );
            const String dateString = "5/01/ 09:00 2009";

            var actual = dateString.TryParsDateTimeExact( new[] { "hh aa", "M/dd/ hh:mm yyyy" },
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Fact]
        public void TryParsDateTimeExactTest()
        {
            var expected = new DateTime( 2009, 5, 1, 9, 0, 0 );
            const String dateString = "5/01/2009 09:00";

            var actual = dateString.TryParsDateTimeExact( "M/dd/yyyy hh:mm",
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Fact]
        public void TryParsDateTimeExactTest1()
        {
            var expected = new DateTime( 2009, 5, 1, 9, 0, 0 );
            const String dateString = "5/01/ 09:00 2009";

            var actual = dateString.TryParsDateTimeExact( "M/dd/ hh:mm yyyy",
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}