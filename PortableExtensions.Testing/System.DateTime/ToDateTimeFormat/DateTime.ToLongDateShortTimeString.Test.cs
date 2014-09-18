#region Using

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
        public void ToLongDateShortTimeStringTestCase()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "f" );
            var actual = dateTime.ToLongDateShortTimeString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToLongDateShortTimeStringTestCase1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "f", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToLongDateShortTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToLongDateShortTimeStringTestCase2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "f", CultureInfo.InvariantCulture );
            var actual = dateTime.ToLongDateShortTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}