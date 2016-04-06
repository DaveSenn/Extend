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
        public void PercentageOfTest()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Int64) 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTest1()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Double) 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTest1DivideByZeroException()
        {
            const Int64 number = 0;
            Action test = () => number.PercentageOf( (Double) 50 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentageOfTest2()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( (Int64) 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTest2DivideByZeroException()
        {
            const Int64 number = 0;
            Action test = () => number.PercentageOf( (Int64) 50 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentageOfTest3()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( new Decimal( 50 ) );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTest3DivideByZeroException()
        {
            const Int64 number = 0;
            Action test = () => number.PercentageOf( new Decimal( 50 ) );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentageOfTest4()
        {
            const Int64 number = 1000;
            const Int32 expected = 500;
            var actual = number.PercentageOf( 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTest4DivideByZeroException()
        {
            const Int64 number = 0;
            Action test = () => number.PercentageOf( 50 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentageOfTestDivideByZeroException()
        {
            const Int64 number = 0;
            Action test = () => number.PercentageOf( (Int64) 50 );

            test.ShouldThrow<DivideByZeroException>();
        }
    }
}