#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void EndOfYearTest()
        {
            var dateTime = RandomValueEx.GetRandomDateTime( DateTime.Now, new DateTime( 3000, 1, 1 ) );
            var expected = new DateTime( dateTime.Year, 1, 1 ).AddYears( 1 )
                                                              .Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfYear();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void EndOfYearTest1()
        {
            var dateTime = new DateTime( 1, 1, 1 );
            var expected = new DateTime( dateTime.Year, 1, 1 ).AddYears( 1 )
                                                              .Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfYear();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void EndOfYearTest2()
        {
            var dateTime = new DateTime( 9999, 12, 31 );
            var expected = new DateTime( 9999, 12, 31, 23, 59, 59, 999 );
            var actual = dateTime.EndOfYear();
            Assert.Equal( expected, actual );
        }
    }
}