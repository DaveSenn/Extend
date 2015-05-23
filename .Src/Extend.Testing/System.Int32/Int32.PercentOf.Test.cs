#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void PercentOfTestCase()
        {
            var number = 1000;
            var expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTestCase1()
        {
            var number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Double) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof (DivideByZeroException) )]
        public void PercentOfTestCase1DivideByZero()
        {
            0.PercentOf( (Double) 100 );
        }

        [Test]
        public void PercentOfTestCase2()
        {
            var number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof (DivideByZeroException) )]
        public void PercentOfTestCase2DivideByZero()
        {
            0.PercentOf( (Int64) 100 );
        }

        [Test]
        [ExpectedException( typeof (DivideByZeroException) )]
        public void PercentOfTestCaseDivideByZero()
        {
            0.PercentOf( 100 );
        }
    }
}