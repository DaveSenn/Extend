#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void NextMonthStartTest()
        {
            var dateTime = DateTime.Now;
            var actual = dateTime.NextMonthStart();

            var expected = dateTime.Month == 12
                ? new DateTime( dateTime.Year + 1, 1, 1 )
                : new DateTime( dateTime.Year, dateTime.Month + 1, 1 );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void NextMonthStartTest1()
        {
            var dateTime = new DateTime( 2014, 08, 12, 12, 12, 5 );
            var expected = new DateTime( 2014, 09, 01 );

            var actual = dateTime.NextMonthStart();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void NextMonthStartTest2()
        {
            var dateTime = new DateTime( 2014, 12, 12, 12, 12, 5 );
            var expected = new DateTime( 2015, 01, 01 );

            var actual = dateTime.NextMonthStart();
            Assert.Equal( expected, actual );
        }
    }
}