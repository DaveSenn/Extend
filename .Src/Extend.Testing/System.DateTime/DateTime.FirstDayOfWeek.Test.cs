#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void FirstDayOfWeekTest()
        {
            var dateTime = RandomValueEx.GetRandomDateTime();
            var expected =
                new DateTime( dateTime.Year, dateTime.Month, dateTime.Day ).AddDays( -(Int32) dateTime.DayOfWeek );
            var actual = dateTime.FirstDayOfWeek();
            Assert.Equal( expected, actual );
        }
    }
}