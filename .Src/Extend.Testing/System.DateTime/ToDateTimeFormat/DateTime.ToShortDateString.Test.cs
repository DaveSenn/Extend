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
        public void ToShortDateStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "d" );
            var actual = DateTimeEx.ToShortDateString( dateTime );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToShortDateStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "d", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToShortDateString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToShortDateStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "d", CultureInfo.InvariantCulture );
            var actual = dateTime.ToShortDateString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}