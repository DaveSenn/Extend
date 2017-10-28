#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void NextWeekDayTest()
        {
            var friday = new DateTime( 2014, 8, 8 );
            var saturday = new DateTime( 2014, 8, 9 );
            var sunday = new DateTime( 2014, 8, 10 );

            var actual = friday.NextWeekDay();
            Assert.Equal( friday, actual );

            actual = saturday.NextWeekDay();
            Assert.Equal( new DateTime( 2014, 8, 11 ), actual );

            actual = sunday.NextWeekDay();
            Assert.Equal( new DateTime( 2014, 8, 11 ), actual );
        }
    }
}