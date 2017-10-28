#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void IsLastDayOfMonthTest()
        {
            var dateTime = new DateTime( 2015, 11, 01 );
            dateTime.IsLastDayOfMonth()
                    .Should()
                    .BeFalse();

            dateTime = new DateTime( 2015, 11, 30 );
            dateTime.IsLastDayOfMonth()
                    .Should()
                    .BeTrue();

            dateTime = new DateTime( 2015, 12, 30 );
            dateTime.IsLastDayOfMonth()
                    .Should()
                    .BeFalse();

            dateTime = new DateTime( 2015, 12, 31 );
            dateTime.IsLastDayOfMonth()
                    .Should()
                    .BeTrue();
        }
    }
}