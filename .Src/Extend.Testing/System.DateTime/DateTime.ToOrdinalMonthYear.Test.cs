#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void ToOrdinalMonthYearTest()
        {
            var date = new DateTime(2011, 2, 11);
            Assert.Equal("February 11th, 2011", date.ToOrdinalMonthYear());
            date = new DateTime(2011, 2, 2);
            Assert.Equal("February 2nd, 2011", date.ToOrdinalMonthYear());
            date = new DateTime(2011, 2, 1);
            Assert.Equal("February 1st, 2011", date.ToOrdinalMonthYear());
            date = new DateTime(2011, 2, 23);
            Assert.Equal("February 23rd, 2011", date.ToOrdinalMonthYear());
            date = new DateTime(2011, 2, 24);
            Assert.Equal("February 24th, 2011", date.ToOrdinalMonthYear());
        }
    }
}