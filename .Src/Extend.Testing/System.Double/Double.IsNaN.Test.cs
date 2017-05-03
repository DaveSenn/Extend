#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    
    public partial class DoubleExTest
    {
        [Fact]
        public void IsNaNTest()
        {
            var number = 10.5;
            var actual = number.IsNaN();

            Assert.Equal( false, actual );

            number = Double.NaN;
            actual = number.IsNaN();

            Assert.Equal( true, actual );
        }
    }
}