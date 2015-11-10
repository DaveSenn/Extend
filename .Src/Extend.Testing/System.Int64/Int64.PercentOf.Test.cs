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
        public void PercentOfTestCase()
        {
            const Int64 number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTestCase1()
        {
            const Int64 number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( (Double) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTestCase1DivideByZero()
        {
            Action test = () => Int64Ex.PercentOf( 0, (Double) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTestCase2()
        {
            const Int64 number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTestCase2DivideByZero()
        {
            Action test = () => Int64Ex.PercentOf( 0, (Int64) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTestCase3()
        {
            const Int64 number = 1000;
            const Int32 expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTestCase3DivideByZero()
        {
            Action test = () => Int64Ex.PercentOf( 0, 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTestCaseDivideByZero()
        {
            Action test = () => Int64Ex.PercentOf( 0, (Int64) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }
    }
}