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
        public void ToLongDateShortTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "f" );
            var actual = dateTime.ToLongDateShortTimeString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToLongDateShortTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "f", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToLongDateShortTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToLongDateShortTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "f", CultureInfo.InvariantCulture );
            var actual = dateTime.ToLongDateShortTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}