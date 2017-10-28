#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void IsAfternoonTest()
        {
            var dateTime = new DateTime( 2014, 10, 10, 13, 0, 0 );
            var actual = dateTime.IsAfternoon();
            Assert.True( actual );

            dateTime = new DateTime( 2014, 10, 10, 10, 0, 0 );
            actual = dateTime.IsAfternoon();
            Assert.False( actual );
        }
    }
}