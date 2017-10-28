#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void IsFutureTest()
        {
            var dateTime = DateTime.Now.Subtract( 1.ToMilliseconds() );
            var actual = dateTime.IsFuture();
            Assert.False( actual );

            dateTime = DateTime.Now.AddDays( 2 );
            actual = dateTime.IsFuture();
            Assert.True( actual );
        }
    }
}