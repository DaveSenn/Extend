#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DoubleExTest
    {
        [Fact]
        public void PercentOfTest()
        {
            const Double number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PercentOfTest1()
        {
            const Double number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( (Double) 500 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PercentOfTest2()
        {
            const Double number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.Equal( expected, actual );
        }
    }
}