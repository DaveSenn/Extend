#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DoubleExTest
    {
        [Fact]
        public void PercentageOfTest()
        {
            const Double number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( 50 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PercentageOfTest1()
        {
            const Double number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Double) 50 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PercentageOfTest2()
        {
            const Double number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Int64) 50 );

            Assert.Equal( expected, actual );
        }
    }
}