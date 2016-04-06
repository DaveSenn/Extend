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
        public void ToLongDateStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "D" );
            var actual = DateTimeEx.ToLongDateString( dateTime );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToLongDateStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "D", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToLongDateString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToLongDateStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "D", CultureInfo.InvariantCulture );
            var actual = dateTime.ToLongDateString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}