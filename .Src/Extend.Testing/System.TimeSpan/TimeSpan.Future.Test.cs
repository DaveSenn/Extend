#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class TimeSpanExTest
    {
        [Fact]
        public void FutureTest()
        {
            var expected = DateTime.Now.Add( TimeSpan.FromDays( 1 ) );
            var actual = TimeSpan.FromDays( 1 )
                                 .Future();

            Assert.Equal( expected.Day, actual.Day );
        }
    }
}