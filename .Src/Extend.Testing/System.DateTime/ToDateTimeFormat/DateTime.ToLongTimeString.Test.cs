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
        public void ToLongTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "T" );
            var actual = DateTimeEx.ToLongTimeString( dateTime );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToLongTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "T", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToLongTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToLongTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "T", CultureInfo.InvariantCulture );
            var actual = dateTime.ToLongTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}