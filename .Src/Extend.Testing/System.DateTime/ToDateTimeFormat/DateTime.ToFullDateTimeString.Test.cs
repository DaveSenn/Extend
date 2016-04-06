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
        public void ToFullDateTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "F" );
            var actual = dateTime.ToFullDateTimeString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToFullDateTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "F", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToFullDateTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToFullDateTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "F", CultureInfo.InvariantCulture );
            var actual = dateTime.ToFullDateTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}