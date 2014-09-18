#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [Test]
        public void PercentOfTestCase()
        {
            Int64 number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( DivideByZeroException ) )]
        public void PercentOfTestCaseDivideByZero()
        {
            Int64Ex.PercentOf( 0, (Int64) 100 );
        }

        [Test]
        public void PercentOfTestCase1()
        {
            Int64 number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Double) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( DivideByZeroException ) )]
        public void PercentOfTestCase1DivideByZero()
        {
            Int64Ex.PercentOf( 0, (Double) 100 );
        }

        [Test]
        public void PercentOfTestCase2()
        {
            Int64 number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( DivideByZeroException ) )]
        public void PercentOfTestCase2DivideByZero()
        {
            Int64Ex.PercentOf( 0, (Int64) 100 );
        }
    }
}