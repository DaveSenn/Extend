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
        public void TryParsDateTimeExactFormatNullTest()
        {
            const String dateString = "5/01/2009 09:00";

            DateTime result;
            String format = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => dateString.TryParsDateTimeExact( format,
                                                                 new CultureInfo( "en-US" ),
                                                                 DateTimeStyles.None,
                                                                 out result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsDateTimeExactFormatProviderNullTest()
        {
            const String dateString = "5/01/2009 09:00";

            DateTime result;
            CultureInfo culture = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => dateString.TryParsDateTimeExact( "M/dd/ hh:mm yyyy",
                                                                 culture,
                                                                 DateTimeStyles.None,
                                                                 out result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsDateTimeExactInvalidDateTimeStyleTest()
        {
            const String dateString = "5/01/2009 09:00";

            DateTime result;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => dateString.TryParsDateTimeExact( "M/dd/ hh:mm yyyy",
                                                                 new CultureInfo( "den-US" ),
                                                                 DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal,
                                                                 out result );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void TryParsDateTimeExactInvalidFormatTest()
        {
            const String dateString = "5/01/ 09:00 2009";

            DateTime result;
            var actual = dateString.TryParsDateTimeExact( "asdasd",
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out result );

            result
                .Should()
                .Be( default(DateTime) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsDateTimeExactInvalidValueTest()
        {
            const String dateString = "asdasd";

            DateTime result;
            var actual = dateString.TryParsDateTimeExact( "M/dd/yyyy hh:mm",
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out result );

            result
                .Should()
                .Be( default(DateTime) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsDateTimeExactNullValueTest()
        {
            String value = null;
            DateTime result;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDateTimeExact( "M/dd/yyyy hh:mm",
                                                     new CultureInfo( "en-US" ),
                                                     DateTimeStyles.None,
                                                     out result );

            result
                .Should()
                .Be( default(DateTime) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsDateTimeExactOverloadFormatNullTest()
        {
            const String dateString = "5/01/2009 09:00";

            DateTime result;
            String[] formats = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => dateString.TryParsDateTimeExact( formats,
                                                                 new CultureInfo( "en-US" ),
                                                                 DateTimeStyles.None,
                                                                 out result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsDateTimeExactOverloadFormatProviderNullTest()
        {
            const String dateString = "5/01/2009 09:00";

            DateTime result;
            CultureInfo culture = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => dateString.TryParsDateTimeExact( new[] { "asd", "M/dd/ hh:mm yyyy" },
                                                                 culture,
                                                                 DateTimeStyles.None,
                                                                 out result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsDateTimeExactOverloadInvalidDateTimeStyleTest()
        {
            const String dateString = "5/01/2009 09:00";

            DateTime result;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => dateString.TryParsDateTimeExact( new[] { "asd", "M/dd/ hh:mm yyyy" },
                                                                 new CultureInfo( "den-US" ),
                                                                 DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal,
                                                                 out result );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void TryParsDateTimeExactOverloadInvalidFormatTest()
        {
            const String dateString = "5/01/ 09:00 2009";

            DateTime result;
            var actual = dateString.TryParsDateTimeExact( new[] { "asdasd", "123" },
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out result );

            result
                .Should()
                .Be( default(DateTime) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsDateTimeExactOverloadInvalidValueTest()
        {
            const String dateString = "asdasd";

            DateTime result;
            var actual = dateString.TryParsDateTimeExact( new[] { "asdasd", "123" },
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out result );

            result
                .Should()
                .Be( default(DateTime) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsDateTimeExactOverloadNullValueTest()
        {
            String value = null;
            DateTime result;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsDateTimeExact( new[] { "asdasd", "123" },
                                                     new CultureInfo( "en-US" ),
                                                     DateTimeStyles.None,
                                                     out result );

            result
                .Should()
                .Be( default(DateTime) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsDateTimeExactOverloadTest()
        {
            var expected = new DateTime( 2009, 5, 1, 9, 0, 0 );
            const String dateString = "5/01/2009 09:00";

            DateTime result;
            var actual = dateString.TryParsDateTimeExact( new[] { "asd", "M/dd/yyyy hh:mm" },
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Test]
        public void TryParsDateTimeExactOverloadTest1()
        {
            var expected = new DateTime( 2009, 5, 1, 9, 0, 0 );
            const String dateString = "5/01/ 09:00 2009";

            DateTime result;
            var actual = dateString.TryParsDateTimeExact( new[] { "hh aa", "M/dd/ hh:mm yyyy" },
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Test]
        public void TryParsDateTimeExactTest()
        {
            var expected = new DateTime( 2009, 5, 1, 9, 0, 0 );
            const String dateString = "5/01/2009 09:00";

            DateTime result;
            var actual = dateString.TryParsDateTimeExact( "M/dd/yyyy hh:mm",
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Test]
        public void TryParsDateTimeExactTest1()
        {
            var expected = new DateTime( 2009, 5, 1, 9, 0, 0 );
            const String dateString = "5/01/ 09:00 2009";

            DateTime result;
            var actual = dateString.TryParsDateTimeExact( "M/dd/ hh:mm yyyy",
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}