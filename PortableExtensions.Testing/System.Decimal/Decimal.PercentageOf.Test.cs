#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DecimalExTest
    {
        [Test]
        public void PercentageOfTestCase ()
        {
            var number = new decimal( 1000 );
            var expected = 500;
            var actual = number.PercentageOf( 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTestCase1 ()
        {
            var number = new decimal( 1000 );
            var expected = 500;
            var actual = number.PercentageOf( new Decimal( 50 ) );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTestCase2 ()
        {
            var number = new decimal( 1000 );
            var expected = 500;
            var actual = number.PercentageOf( (Int64) 50 );

            Assert.AreEqual( expected, actual );
        }
    }
}