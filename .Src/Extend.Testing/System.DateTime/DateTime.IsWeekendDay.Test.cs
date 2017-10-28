#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void IsWeekendDayTest()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var actual = dateTime.IsWeekendDay();
            Assert.False( actual );

            dateTime = new DateTime( 2014, 3, 29 );
            actual = dateTime.IsWeekendDay();
            Assert.True( actual );
        }
    }
}