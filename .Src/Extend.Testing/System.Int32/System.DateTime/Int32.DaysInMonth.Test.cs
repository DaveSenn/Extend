#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void DaysInMonthTest()
        {
            var year = RandomValueEx.GetRandomInt32( 1990, 2015 );
            var month = RandomValueEx.GetRandomInt32( 1, 12 );

            var expected = DateTime.DaysInMonth( year, month );
            var actual = year.DaysInMonth( month );
            Assert.Equal( expected, actual );
        }
    }
}