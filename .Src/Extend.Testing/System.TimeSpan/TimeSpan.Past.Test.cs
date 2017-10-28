#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class TimeSpanExTest
    {
        [Fact]
        public void FPastTest()
        {
            var expected = DateTime.Now.Subtract( TimeSpan.FromDays( 1 ) );
            var actual = TimeSpan.FromDays( 1 )
                                 .Past();

            Assert.Equal( expected.Day, actual.Day );
        }
    }
}