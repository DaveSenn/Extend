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
        public void ToSortableDateTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "s" );
            var actual = dateTime.ToSortableDateTimeString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToSortableDateTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "s", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToSortableDateTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToSortableDateTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "s", CultureInfo.InvariantCulture );
            var actual = dateTime.ToSortableDateTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}