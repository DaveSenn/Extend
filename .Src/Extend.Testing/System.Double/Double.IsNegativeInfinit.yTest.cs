#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    
    public partial class DoubleExTest
    {
        [Fact]
        public void IsNegativeInfinityTest()
        {
            var number = 10.5;
            var actual = number.IsNegativeInfinity();

            Assert.Equal( false, actual );

            number = Double.NegativeInfinity;
            actual = number.IsNegativeInfinity();

            Assert.Equal( true, actual );

            number = Double.PositiveInfinity;
            actual = number.IsNegativeInfinity();

            Assert.Equal( false, actual );
        }
    }
}