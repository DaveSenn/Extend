#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DoubleExTest
    {
        [Fact]
        public void ToMillisecondsTest()
        {
            const Double number = 10.5;
            var expected = TimeSpan.FromMilliseconds( number );
            var actual = number.ToMilliseconds();

            Assert.Equal( expected, actual );
        }
    }
}