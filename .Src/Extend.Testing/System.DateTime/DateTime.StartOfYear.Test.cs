#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void StartOfYearTest()
        {
            var dateTime = DateTime.Today;
            var expected = new DateTime( dateTime.Year, 1, 1 );
            var actual = dateTime.StartOfYear();

            Assert.Equal( expected, actual );
        }
    }
}