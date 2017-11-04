#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DoubleExTest
    {
        [Fact]
        public void ToHoursTest()
        {
            const Double number = 10.5;
            var expected = TimeSpan.FromHours( number );
            var actual = number.ToHours();

            Assert.Equal( expected, actual );
        }
    }
}