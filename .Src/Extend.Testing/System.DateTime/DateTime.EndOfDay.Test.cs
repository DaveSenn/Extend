#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void EndOfDayTest()
        {
            var dateTime = DateTime.Now;
            var expected =
                new DateTime( dateTime.Year, dateTime.Month, dateTime.Day ).AddDays( 1 )
                                                                           .Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfDay();
            Assert.Equal( expected, actual );
        }
    }
}