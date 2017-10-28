#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int16ExTest
    {
        [Fact]
        public void PercentageOfTest()
        {
            const Int16 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( 50 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PercentageOfTest1()
        {
            const Int16 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Double) 50 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PercentageOfTest2()
        {
            const Int16 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Int64) 50 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PercentageOfTest3()
        {
            const Int16 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( new Decimal( 50 ) );

            Assert.Equal( expected, actual );
        }
    }
}