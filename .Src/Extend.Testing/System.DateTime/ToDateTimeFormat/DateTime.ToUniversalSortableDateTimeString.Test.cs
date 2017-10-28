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
        public void ToUniversalSortableDateTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "u" );
            var actual = dateTime.ToUniversalSortableDateTimeString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToUniversalSortableDateTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "u", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToUniversalSortableDateTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToUniversalSortableDateTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "u", CultureInfo.InvariantCulture );
            var actual = dateTime.ToUniversalSortableDateTimeString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}