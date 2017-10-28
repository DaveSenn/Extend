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
        public void GetWeekOfYearTest()
        {
            var dateTime = new DateTime( 2014, 12, 29 );

            var actual = dateTime.GetWeekOfYear();
            actual.Should()
                  .Be( 1 );
        }

        [Fact]
        public void GetWeekOfYearTest1()
        {
            var dateTime = new DateTime( 2015, 11, 10 );

            var actual = dateTime.GetWeekOfYear();
            actual.Should()
                  .Be( 46 );
        }

        [Fact]
        public void GetWeekOfYearTest2()
        {
            var dateTime = new DateTime( 2015, 12, 31 );

            var actual = dateTime.GetWeekOfYear();
            actual.Should()
                  .Be( 53 );
        }

        [Fact]
        public void GetWeekOfYearTest3()
        {
            var dateTime = new DateTime( 2015, 12, 27 );

            var actual = dateTime.GetWeekOfYear();
            actual.Should()
                  .Be( 52 );
        }

        [Fact]
        public void GetWeekOfYearTest4()
        {
            var dateTime = new DateTime( 2015, 04, 18 );

            var actual = dateTime.GetWeekOfYear();
            actual.Should()
                  .Be( 16 );
        }
    }
}