#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void TryParsDateTimeExactTestCase()
        {
            var dateString = "5/01/2009 09:00";
            var actual = DateTime.ParseExact( dateString,
                                              "M/dd/yyyy hh:mm",
                                              new CultureInfo( "en-US" ),
                                              DateTimeStyles.None );

            var expected = new DateTime( 2009, 5, 1, 9, 0, 0 );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsDateTimeExactTestCaseNullCheck()
        {
            var outValue = DateTime.Now;
            StringEx.TryParsDateTimeExact( null,
                                           "",
                                           CultureInfo.InvariantCulture,
                                           DateTimeStyles.AllowTrailingWhite,
                                           out outValue );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsDateTimeExactTestCaseNullCheck1()
        {
            var outValue = DateTime.Now;
            String s = null;
            "".TryParsDateTimeExact( s, CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out outValue );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsDateTimeExactTestCaseNullCheck2()
        {
            var outValue = DateTime.Now;
            "".TryParsDateTimeExact( "", null, DateTimeStyles.AllowTrailingWhite, out outValue );
        }

        [Test]
        public void TryParsDateTimeExactTestCase1()
        {
            var formats = new[]
            {
                "M/d/yyyy h:mm:ss tt",
                "M/d/yyyy h:mm tt",
                "MM/dd/yyyy hh:mm:ss",
                "M/d/yyyy h:mm:ss",
                "M/d/yyyy hh:mm tt",
                "M/d/yyyy hh tt",
                "M/d/yyyy h:mm",
                "M/d/yyyy h:mm",
                "MM/dd/yyyy hh:mm",
                "M/dd/yyyy hh:mm"
            };

            var expected = new DateTime( 2009, 5, 1, 6, 32, 0 );
            var dateString = "5/1/2009 6:32 AM";

            var actual = DateTime.ParseExact( dateString, formats, new CultureInfo( "en-US" ), DateTimeStyles.None );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsDateTimeExactTestCase1NullCheck()
        {
            var outValue = DateTime.Now;
            StringEx.TryParsDateTimeExact( null,
                                           new[]
                                           {
                                               "test"
                                           },
                                           CultureInfo.InvariantCulture,
                                           DateTimeStyles.AllowTrailingWhite,
                                           out outValue );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsDateTimeExactTestCase1NullCheck1()
        {
            var outValue = DateTime.Now;
            String[] s = null;
            "".TryParsDateTimeExact( s, CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out outValue );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsDateTimeExactTestCase1NullCheck2()
        {
            var outValue = DateTime.Now;
            "".TryParsDateTimeExact( new[]
            {
                "test"
            },
                                     null,
                                     DateTimeStyles.AllowTrailingWhite,
                                     out outValue );
        }
    }
}

/*
        /// <summary>
        ///     replace
        /// </summary>
        /// <exception cref="ArgumentNullException">The formats can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to pars.</param>
        /// <param name="outValue">The parsed value.</param>
        /// <param name="formats">The formats of the date time value in the string</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="dateTimeStyle">The date time style.</param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsDateTimeExact( this String value, String[] formats, IFormatProvider formatProvider,
                                                    DateTimeStyles dateTimeStyle, out DateTime outValue )
        {
            value.ThrowIfNull(() => value);
            formats.ThrowIfNull( () => formats );
            formatProvider.ThrowIfNull( () => formatProvider );

            return DateTime.TryParseExact( value, formats, formatProvider, dateTimeStyle, out outValue );
        }
 */