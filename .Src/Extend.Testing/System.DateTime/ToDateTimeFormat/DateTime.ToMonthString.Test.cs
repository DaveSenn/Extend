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
        public void ToMonthStringTestCase()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "MMMM" );
            var actual = dateTime.ToMonthString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToMonthStringTestCase1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "MMMM", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToMonthString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToMonthStringTestCase2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "MMMM", new CultureInfo( "de-CH" ) );
            var actual = dateTime.ToMonthString( new CultureInfo( "de-CH" ) );
            Assert.AreEqual( expected, actual );
        }
    }
}