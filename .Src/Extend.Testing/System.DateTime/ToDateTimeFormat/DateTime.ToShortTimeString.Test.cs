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
        public void ToShortTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "t" );
            var actual = DateTimeEx.ToShortTimeString( dateTime );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToShortTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "t", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToShortTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToShortTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "t", CultureInfo.InvariantCulture );
            var actual = dateTime.ToShortTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}