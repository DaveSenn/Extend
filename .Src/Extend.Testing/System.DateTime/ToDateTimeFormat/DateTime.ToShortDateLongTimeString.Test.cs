#region Usings

using System;
using System.Globalization;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void ToShortDateLongTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "G" );
            var actual = dateTime.ToShortDateLongTimeString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToShortDateLongTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "G", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToShortDateLongTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToShortDateLongTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "G", CultureInfo.InvariantCulture );
            var actual = dateTime.ToShortDateLongTimeString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}