#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void StartOfMonthTest()
        {
            var dateTime = DateTime.Today;
            var expected = new DateTime( dateTime.Year, dateTime.Month, 1 );
            var actual = dateTime.StartOfMonth();

            Assert.Equal( expected, actual );
        }
    }
}