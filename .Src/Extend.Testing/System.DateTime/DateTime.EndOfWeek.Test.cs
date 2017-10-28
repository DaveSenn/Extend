#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void EndOfWeekTest()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var expected = new DateTime( 2014, 3, 30 ).AddDays( 1 )
                                                      .Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfWeek();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void EndOfWeekTest1()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var expected = new DateTime( 2014, 3, 31 ).AddDays( 1 )
                                                      .Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfWeek( DayOfWeek.Monday );
            Assert.Equal( expected, actual );
        }
    }
}