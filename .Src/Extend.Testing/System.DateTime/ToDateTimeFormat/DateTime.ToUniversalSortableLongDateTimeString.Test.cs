#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [Test]
        public void ToUniversalSortableLongDateTimeStringTestCase()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "U" );
            var actual = dateTime.ToUniversalSortableLongDateTimeString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToUniversalSortableLongDateTimeStringTestCase1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "U", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToUniversalSortableLongDateTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToUniversalSortableLongDateTimeStringTestCase2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "U", CultureInfo.InvariantCulture );
            var actual = dateTime.ToUniversalSortableLongDateTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}