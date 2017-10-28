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
        public void ToMonthDayStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "m" );
            var actual = dateTime.ToMonthDayString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToMonthDayStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "m", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToMonthDayString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToMonthDayStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "m", CultureInfo.InvariantCulture );
            var actual = dateTime.ToMonthDayString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}