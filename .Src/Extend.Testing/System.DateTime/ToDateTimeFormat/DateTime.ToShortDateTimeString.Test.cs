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
        public void ToShortDateTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "g" );
            var actual = dateTime.ToShortDateTimeString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToShortDateTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "g", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToShortDateTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToShortDateTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "g", CultureInfo.InvariantCulture );
            var actual = dateTime.ToShortDateTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}