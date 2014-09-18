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
        public void ToShortDateTimeStringTestCase()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "g" );
            var actual = dateTime.ToShortDateTimeString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToShortDateTimeStringTestCase1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "g", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToShortDateTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToShortDateTimeStringTestCase2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "g", CultureInfo.InvariantCulture );
            var actual = dateTime.ToShortDateTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}