#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DoubleExTest
    {
        [Fact]
        public void ToDaysTest()
        {
            const Double number = 10.5;
            var expected = TimeSpan.FromDays( number );
            var actual = number.ToDays();

            Assert.Equal( expected, actual );
        }
    }
}