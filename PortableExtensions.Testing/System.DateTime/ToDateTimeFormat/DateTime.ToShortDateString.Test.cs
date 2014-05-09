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
        [TestCase]
        public void ToShortDateStringTestCase()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "d" );
            var actual = dateTime.ToShortDateString();
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void ToShortDateStringTestCase1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "d", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToShortDateString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void ToShortDateStringTestCase2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "d", CultureInfo.InvariantCulture );
            var actual = dateTime.ToShortDateString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}