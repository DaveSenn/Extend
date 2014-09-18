#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DoubleExTest
    {
        [Test]
        public void PercentOfTestCase()
        {
            Double number = 1000;
            var expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( DivideByZeroException ) )]
        public void PercentOfTestCaseDivideByZero()
        {
            DoubleEx.PercentOf( 0, 100 );
        }

        [Test]
        public void PercentOfTestCase1()
        {
            Double number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Double) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( DivideByZeroException ) )]
        public void PercentOfTestCase1DivideByZero()
        {
            DoubleEx.PercentOf( 0, (Double) 100 );
        }

        [Test]
        public void PercentOfTestCase2()
        {
            Double number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( DivideByZeroException ) )]
        public void PercentOfTestCase2DivideByZero()
        {
            DoubleEx.PercentOf( 0, (Int64) 100 );
        }
    }
}