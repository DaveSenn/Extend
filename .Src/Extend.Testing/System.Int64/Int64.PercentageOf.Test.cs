#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [Test]
        public void PercentageOfTestCase()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Int64) 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTestCase1()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Double) 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTestCase1DivideByZeroException()
        {
            const Int64 number = 0;
            Action test = () => number.PercentageOf( (Double) 50 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentageOfTestCase2()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Int64) 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTestCase2DivideByZeroException()
        {
            const Int64 number = 0;
            Action test = () => number.PercentageOf( (Int64) 50 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentageOfTestCase3()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( new Decimal( 50 ) );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTestCase3DivideByZeroException()
        {
            const Int64 number = 0;
            Action test = () => number.PercentageOf( new Decimal( 50 ) );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentageOfTestCase4()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTestCase4DivideByZeroException()
        {
            const Int64 number = 0;
            Action test = () => number.PercentageOf( 50 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentageOfTestCaseDivideByZeroException()
        {
            const Int64 number = 0;
            Action test = () => number.PercentageOf( (Int64) 50 );

            test.ShouldThrow<DivideByZeroException>();
        }
    }
}