#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void PercentOfTest()
        {
            const Int32 number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PercentOfTest1()
        {
            const Int32 number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( (Double) 500 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PercentOfTest1DivideByZero()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 0.PercentOf( (Double) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void PercentOfTest2()
        {
            const Int32 number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PercentOfTest2DivideByZero()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 0.PercentOf( (Int64) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Fact]
        public void PercentOfTestDivideByZero()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 0.PercentOf( 100 );

            test.ShouldThrow<DivideByZeroException>();
        }
    }
}