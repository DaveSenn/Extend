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
        public void ToMonthDayStringTestCase()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "m" );
            var actual = dateTime.ToMonthDayString();
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void ToMonthDayStringTestCase1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "m", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToMonthDayString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void ToMonthDayStringTestCase2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "m", CultureInfo.InvariantCulture );
            var actual = dateTime.ToMonthDayString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}