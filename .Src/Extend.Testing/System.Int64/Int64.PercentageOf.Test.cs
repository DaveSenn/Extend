#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int64ExTest
    {
        [Fact]
        public void PercentageOfTest()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Int64) 50 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PercentageOfTest0ValueTest()
        {
            const Int64 number = 0;
            var actual = number.PercentageOf( (Int64) 50 );
            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void PercentageOfTest0ValueTest1()
        {
            const Int64 number = 0;
            var actual = number.PercentageOf( 50 );
            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void PercentageOfTest0ValueTest2()
        {
            const Int64 number = 0;
            var actual = number.PercentageOf( (Double) 50 );
            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void PercentageOfTest0ValueTest3()
        {
            const Int64 number = 0;
            var actual = number.PercentageOf( (Int64) 50 );
            actual
                .Should()
                .Be( 0 );
        }

        [Fact]
        public void PercentageOfTest0ValueTest4()
        {
            const Int64 number = 0;
            var actual = number.PercentageOf( new Decimal( 50 ) );

            actual.Should()
                  .Be( 0 );
        }

        [Fact]
        public void PercentageOfTest1()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Double) 50 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PercentageOfTest2()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Int64) 50 );

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void PercentageOfTest3()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( new Decimal( 50 ) );

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void PercentageOfTest4()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( 50 );

            actual.Should()
                  .Be( expected );
        }
    }
}