#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DoubleExTest
    {
        [Fact]
        public void IsInfinityTest()
        {
            var number = 10.5;
            var actual = number.IsInfinity();

            Assert.False( actual );

            number = Double.NegativeInfinity;
            actual = number.IsInfinity();

            Assert.True( actual );

            number = Double.PositiveInfinity;
            actual = number.IsInfinity();

            Assert.True( actual );
        }
    }
}