#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void IsWeekdDayTest()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var actual = dateTime.IsWeekdDay();
            Assert.True( actual );

            dateTime = new DateTime( 2014, 3, 29 );
            actual = dateTime.IsWeekdDay();
            Assert.False( actual );
        }
    }
}