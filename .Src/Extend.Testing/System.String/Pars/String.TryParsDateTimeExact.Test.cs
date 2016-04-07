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
        public void TryParsDateTimeExactTest()
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
        public void TryParsDateTimeExactTest1()
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
        public void TryParsDateTimeExactTest1NullCheck1()
        {
            var outValue = DateTime.Now;
            String[] s = null;
            Action test = () => "".TryParsDateTimeExact( s, CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsDateTimeExactTest1NullCheck2()
        {
            var outValue = DateTime.Now;
            Action test = () => "".TryParsDateTimeExact(
                new[]
                {
                    "test"
                },
                null,
                DateTimeStyles.AllowTrailingWhite,
                out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsDateTimeExactTest2()
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
        public void TryParsDateTimeExactTest3()
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
        public void TryParsDateTimeExactTestNullCheck1()
        {
            var outValue = DateTime.Now;
            String s = null;
            Action test = () => "".TryParsDateTimeExact( s, CultureInfo.InvariantCulture, DateTimeStyles.AllowTrailingWhite, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsDateTimeExactTestNullCheck2()
        {
            var outValue = DateTime.Now;
            Action test = () => "".TryParsDateTimeExact( "", null, DateTimeStyles.AllowTrailingWhite, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}