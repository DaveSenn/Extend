#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DoubleExTest
    {
        [Fact]
        public void ToMinutesTest()
        {
            const Double number = 10.5;
            var expected = TimeSpan.FromMinutes( number );
            var actual = number.ToMinutes();

            Assert.Equal( expected, actual );
        }
    }
}