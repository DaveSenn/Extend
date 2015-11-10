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
        public void PercentOfTestCase()
        {
            var number = new Decimal( 1000 );
            var expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTestCase1()
        {
            var number = new Decimal( 1000 );
            var expected = 50;
            var actual = number.PercentOf( new Decimal( 500 ) );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTestCase1DivideByZero()
        {
            Action test = () => DecimalEx.PercentOf( 0, new Decimal( 10 ) );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTestCase2()
        {
            var number = new Decimal( 1000 );
            var expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTestCase2DivideByZero()
        {
            Action test = () => DecimalEx.PercentOf( 0, (Int64) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTestCaseDivideByZero()
        {
            Action test = () => DecimalEx.PercentOf( 0, 100 );

            test.ShouldThrow<DivideByZeroException>();
        }
    }
}