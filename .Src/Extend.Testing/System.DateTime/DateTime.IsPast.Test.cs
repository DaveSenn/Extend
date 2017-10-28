#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void IsPastTest()
        {
            var dateTime = DateTime.Now.Subtract( 1.ToMilliseconds() );
            var actual = dateTime.IsPast();
            Assert.True( actual );

            dateTime = DateTime.Now.AddDays( 2 );
            actual = dateTime.IsPast();
            Assert.False( actual );
        }
    }
}