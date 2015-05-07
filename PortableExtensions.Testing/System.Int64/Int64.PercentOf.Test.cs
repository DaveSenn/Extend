#region Usings

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
        [ExpectedException( typeof (DivideByZeroException) )]
        public void PercentOfTestCase1DivideByZero()
        {
            Int64Ex.PercentOf( 0, (Double) 100 );
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
        [ExpectedException( typeof (DivideByZeroException) )]
        public void PercentOfTestCase2DivideByZero()
        {
            Int64Ex.PercentOf( 0, (Int64) 100 );
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
        [ExpectedException( typeof (DivideByZeroException) )]
        public void PercentOfTestCase3DivideByZero()
        {
            Int64Ex.PercentOf( 0, 100 );
        }

        [Test]
        [ExpectedException( typeof (DivideByZeroException) )]
        public void PercentOfTestCaseDivideByZero()
        {
            Int64Ex.PercentOf( 0, (Int64) 100 );
        }
    }
}