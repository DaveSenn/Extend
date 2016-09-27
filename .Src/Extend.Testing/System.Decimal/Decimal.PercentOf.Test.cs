#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class DecimalExTest
    {
        [Test]
        public void PercentOfTest()
        {
            var number = new Decimal( 1000 );
            const Int32 expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTest1()
        {
            var number = new Decimal( 1000 );
            const Int32 expected = 50;
            var actual = number.PercentOf( new Decimal( 500 ) );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTest1DivideByZero()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => DecimalEx.PercentOf( 0, new Decimal( 10 ) );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTest2()
        {
            var number = new Decimal( 1000 );
            const Int32 expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTest2DivideByZero()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => DecimalEx.PercentOf( 0, (Int64) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTestDivideByZero()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => DecimalEx.PercentOf( 0, 100 );

            test.ShouldThrow<DivideByZeroException>();
        }
    }
}