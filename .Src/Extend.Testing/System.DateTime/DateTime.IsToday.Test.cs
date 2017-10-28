#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void IsTodayTest()
        {
            var dateTime = DateTime.Now;
            var actual = dateTime.IsToday();
            Assert.True( actual );

            dateTime = DateTime.Now.AddDays( 2 );
            actual = dateTime.IsToday();
            Assert.False( actual );
        }
    }
}