#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [Test]
        public void PercentOfTestCase ()
        {
            Int16 number = 1000;
            var expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTestCase1 ()
        {
            Int16 number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Double) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException ( typeof (DivideByZeroException) )]
        public void PercentOfTestCase1DivideByZero ()
        {
            Int16Ex.PercentOf( 0, (Double) 100 );
        }

        [Test]
        public void PercentOfTestCase2 ()
        {
            Int16 number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException ( typeof (DivideByZeroException) )]
        public void PercentOfTestCase2DivideByZero ()
        {
            Int16Ex.PercentOf( 0, (Int64) 100 );
        }

        [Test]
        [ExpectedException ( typeof (DivideByZeroException) )]
        public void PercentOfTestCaseDivideByZero ()
        {
            Int16Ex.PercentOf( 0, 100 );
        }
    }
}