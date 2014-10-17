#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [Test]
        public void ToUniversalSortableDateTimeStringTestCase ()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "u" );
            var actual = dateTime.ToUniversalSortableDateTimeString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToUniversalSortableDateTimeStringTestCase1 ()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "u", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToUniversalSortableDateTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToUniversalSortableDateTimeStringTestCase2 ()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "u", CultureInfo.InvariantCulture );
            var actual = dateTime.ToUniversalSortableDateTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}