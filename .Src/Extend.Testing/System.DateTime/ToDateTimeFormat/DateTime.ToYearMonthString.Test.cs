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
        public void ToYearMonthStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "y" );
            var actual = dateTime.ToYearMonthString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToYearMonthStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "y", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToYearMonthString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToYearMonthStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "y", CultureInfo.InvariantCulture );
            var actual = dateTime.ToYearMonthString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}