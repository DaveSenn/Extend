#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DecimalExTest
    {
        [TestCase]
        public void PercentOfTestCase()
        {
            var number = new decimal( 1000 );
            var expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( DivideByZeroException ) )]
        public void PercentOfTestCaseDivideByZero()
        {
            DecimalEx.PercentOf( 0, 100 );
        }

        [TestCase]
        public void PercentOfTestCase1()
        {
            var number = new decimal( 1000 );
            var expected = 50;
            var actual = number.PercentOf( new Decimal( 500 ) );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( DivideByZeroException ) )]
        public void PercentOfTestCase1DivideByZero()
        {
            DecimalEx.PercentOf( 0, new Decimal( 10 ) );
        }

        [TestCase]
        public void PercentOfTestCase2()
        {
            var number = new decimal( 1000 );
            var expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( DivideByZeroException ) )]
        public void PercentOfTestCase2DivideByZero()
        {
            DecimalEx.PercentOf( 0, (Int64) 100 );
        }
    }
}