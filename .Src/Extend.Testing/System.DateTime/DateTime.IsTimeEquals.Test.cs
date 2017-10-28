#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void IsTimeEqualTest()
        {
            var dateTime = DateTime.Now;
            var dateTime1 = dateTime.AddDays( -2 );

            var actual = dateTime.IsTimeEquals( dateTime1 );
            Assert.True( actual );

            dateTime1 = dateTime.AddDays( -2 )
                                .AddHours( 1 );

            actual = dateTime.IsTimeEquals( dateTime1 );
            Assert.False( actual );
        }
    }
}