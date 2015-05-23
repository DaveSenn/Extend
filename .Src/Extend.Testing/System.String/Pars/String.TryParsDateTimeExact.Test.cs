﻿#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void TryParsDateTimeExactTestCase()
        {
            const String dateString = "5/01/2009 09:00";

            DateTime actual;
            var result = dateString.TryParsDateTimeExact( "M/dd/yyyy hh:mm",
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out actual );

            var expected = new DateTime( 2009, 5, 1, 9, 0, 0 );
            Assert.AreEqual( expected, actual );
            Assert.IsTrue( result );
        }

        [Test]
        public void TryParsDateTimeExactTestCase1()
        {
            const String dateString = "5/01/2009 09:00";

            DateTime actual;
            var result = dateString.TryParsDateTimeExact( "Mm/dd/yyyy hh:mm",
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out actual );

            Assert.AreEqual( DateTime.MinValue, actual );
            Assert.IsFalse( result );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
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
        [ExpectedException( typeof (ArgumentNullException) )]
        public void TryParsDateTimeExactTestCase1NullCheck1()
        {
            var outValue = DateTime.Now;
            String[] s = null;
            "".TryParsDateTimeExact( s, CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out outValue );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
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

        [Test]
        public void TryParsDateTimeExactTestCase2()
        {
            const String dateString = "5/01/2009 09:00";

            DateTime actual;
            var result = dateString.TryParsDateTimeExact( new[] { "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm" },
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out actual );

            var expected = new DateTime( 2009, 5, 1, 9, 0, 0 );
            Assert.AreEqual( expected, actual );
            Assert.IsTrue( result );
        }

        [Test]
        public void TryParsDateTimeExactTestCase3()
        {
            const String dateString = "5/01/2009 09:00";

            DateTime actual;
            var result = dateString.TryParsDateTimeExact( new[] { "MM/dd/yyyy hh:mm", "MM/dd/yyyy hh:mm" },
                                                          new CultureInfo( "en-US" ),
                                                          DateTimeStyles.None,
                                                          out actual );

            Assert.AreEqual( DateTime.MinValue, actual );
            Assert.IsFalse( result );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
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
        [ExpectedException( typeof (ArgumentNullException) )]
        public void TryParsDateTimeExactTestCaseNullCheck1()
        {
            var outValue = DateTime.Now;
            String s = null;
            "".TryParsDateTimeExact( s, CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out outValue );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void TryParsDateTimeExactTestCaseNullCheck2()
        {
            var outValue = DateTime.Now;
            "".TryParsDateTimeExact( "", null, DateTimeStyles.AllowTrailingWhite, out outValue );
        }
    }
}