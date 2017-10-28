#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void YesterdayTest()
        {
            var dateTime = DateTime.Today;
            var expected = dateTime.AddDays( -1 );
            var actual = dateTime.Yesterday();

            Assert.Equal( expected, actual );
        }
    }
}