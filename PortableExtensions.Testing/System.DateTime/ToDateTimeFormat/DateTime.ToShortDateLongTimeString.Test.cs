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
        public void ToShortDateLongTimeStringTestCase ()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "G" );
            var actual = dateTime.ToShortDateLongTimeString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToShortDateLongTimeStringTestCase1 ()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "G", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToShortDateLongTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToShortDateLongTimeStringTestCase2 ()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "G", CultureInfo.InvariantCulture );
            var actual = dateTime.ToShortDateLongTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}