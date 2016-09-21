#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void PercentOfTest()
        {
            var number = 1000;
            var expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTest1()
        {
            var number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Double) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTest1DivideByZero()
        {
            Action test = () => 0.PercentOf( (Double) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTest2()
        {
            var number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTest2DivideByZero()
        {
            Action test = () => 0.PercentOf( (Int64) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTestDivideByZero()
        {
            Action test = () => 0.PercentOf( 100 );

            test.ShouldThrow<DivideByZeroException>();
        }
    }
}