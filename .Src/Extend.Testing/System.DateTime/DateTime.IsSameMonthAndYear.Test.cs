#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void IsSameMonthAndYearTest()
        {
            var dateTime = DateTime.Now;
            var otherDateTime = DateTime.Now;

            Assert.True( dateTime.IsSameMonthAndYear( otherDateTime ) );
        }

        [Fact]
        public void IsSameMonthAndYearTest1()
        {
            var dateTime = new DateTime( 2014, 08, 10 );
            var otherDateTime = new DateTime( 2014, 08, 1 );

            Assert.True( dateTime.IsSameMonthAndYear( otherDateTime ) );
        }

        [Fact]
        public void IsSameMonthAndYearTest2()
        {
            var dateTime = new DateTime( 2014, 08, 10 );
            var otherDateTime = new DateTime( 2014, 09, 1 );

            Assert.False( dateTime.IsSameMonthAndYear( otherDateTime ) );
        }

        [Fact]
        public void IsSameMonthAndYearTest3()
        {
            var dateTime = new DateTime( 2014, 08, 10 );
            var otherDateTime = new DateTime( 2013, 08, 1 );

            Assert.False( dateTime.IsSameMonthAndYear( otherDateTime ) );
        }
    }
}