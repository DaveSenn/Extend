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
        public void ToSortableDateTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "s" );
            var actual = dateTime.ToSortableDateTimeString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToSortableDateTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "s", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToSortableDateTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToSortableDateTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "s", CultureInfo.InvariantCulture );
            var actual = dateTime.ToSortableDateTimeString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}