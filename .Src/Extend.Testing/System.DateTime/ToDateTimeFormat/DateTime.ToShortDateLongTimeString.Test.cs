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
        public void ToShortDateLongTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "G" );
            var actual = dateTime.ToShortDateLongTimeString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToShortDateLongTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "G", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToShortDateLongTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToShortDateLongTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "G", CultureInfo.InvariantCulture );
            var actual = dateTime.ToShortDateLongTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}