#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    
    public partial class DoubleExTest
    {
        [Fact]
        public void IsPositiveInfinityTest()
        {
            var number = 10.5;
            var actual = number.IsPositiveInfinity();

            Assert.Equal( false, actual );

            number = Double.NegativeInfinity;
            actual = number.IsPositiveInfinity();

            Assert.Equal( false, actual );

            number = Double.PositiveInfinity;
            actual = number.IsPositiveInfinity();

            Assert.Equal( true, actual );
        }
    }
}