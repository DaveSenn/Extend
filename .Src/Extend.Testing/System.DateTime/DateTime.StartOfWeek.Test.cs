#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void StartOfWeekTest()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var expected = new DateTime( 2014, 3, 24 );
            var actual = dateTime.StartOfWeek();

            Assert.Equal( expected, actual );

            expected = new DateTime( 2014, 3, 26 );
            actual = dateTime.StartOfWeek( DayOfWeek.Wednesday );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void StartOfWeekTest1()
        {
            var dateTime = new DateTime( 2014, 3, 27 );

            var expected = new DateTime( 2014, 3, 26 );
            var actual = dateTime.StartOfWeek( DayOfWeek.Wednesday );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void StartOfWeekTest2()
        {
            var week = new DateTime( 2014, 09, 21 );
            var expected = new DateTime( 2014, 09, 20 );
            var actual = week.StartOfWeek( DayOfWeek.Saturday );

            Assert.Equal( expected, actual );
        }
    }
}