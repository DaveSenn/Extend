#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DoubleExTest
    {
        [Fact]
        public void ToSecondsTest()
        {
            const Double number = 10.5;
            var expected = TimeSpan.FromSeconds( number );
            var actual = number.ToSeconds();

            Assert.Equal( expected, actual );
        }
    }
}