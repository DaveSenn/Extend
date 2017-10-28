#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void EndOfMonthTest()
        {
            var dateTime = DateTime.Now;
            var expected = new DateTime( dateTime.Year, dateTime.Month, 1 ).AddMonths( 1 )
                                                                           .Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfMonth();
            Assert.Equal( expected, actual );
        }
    }
}