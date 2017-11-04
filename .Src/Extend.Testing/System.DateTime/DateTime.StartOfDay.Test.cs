#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void StartOfDaykTest()
        {
            var dateTime = new DateTime( 2014, 3, 30, 12, 0, 2 );
            var actual = dateTime.StartOfDay();

            Assert.Equal( new DateTime( 2014, 3, 30 ), actual );

            dateTime = new DateTime( 2014, 3, 28, 5, 12, 2 );
            actual = dateTime.StartOfDay();

            Assert.Equal( new DateTime( 2014, 3, 28 ), actual );
        }
    }
}