#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [Test]
        public void PercentOfTest()
        {
            const Int16 number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTest1()
        {
            const Int16 number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( (Double) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTest1DivideByZero()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => Int16Ex.PercentOf( 0, (Double) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTest2()
        {
            const Int16 number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTest2DivideByZero()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => Int16Ex.PercentOf( 0, (Int64) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTestDivideByZero()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => Int16Ex.PercentOf( 0, 100 );

            test.ShouldThrow<DivideByZeroException>();
        }
    }
}