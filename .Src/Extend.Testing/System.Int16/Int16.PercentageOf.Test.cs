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
        public void PercentageOfTestCase()
        {
            Int16 number = 1000;
            var expected = 500;
            var actual = number.PercentageOf( 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTestCase1()
        {
            Int16 number = 1000;
            var expected = 500;
            var actual = number.PercentageOf( (Double) 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTestCase2()
        {
            Int16 number = 1000;
            var expected = 500;
            var actual = number.PercentageOf( (Int64) 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTestCase3()
        {
            Int16 number = 1000;
            var expected = 500;
            var actual = number.PercentageOf( new Decimal( 50 ) );

            Assert.AreEqual( expected, actual );
        }
    }
}