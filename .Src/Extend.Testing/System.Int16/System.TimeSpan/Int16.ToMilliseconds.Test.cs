#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int16ExTest
    {
        [Fact]
        public void ToMillisecondsTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromMilliseconds( value );
            var actual = ( (Int16) value ).ToMilliseconds();
            Assert.Equal( expected, actual );
        }
    }
}