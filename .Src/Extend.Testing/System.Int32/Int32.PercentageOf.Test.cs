#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void PercentageOfTest()
        {
            var number = 1000;
            var expected = 500;
            var actual = number.PercentageOf( 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTest1()
        {
            var number = 1000;
            var expected = 500;
            var actual = number.PercentageOf( (Double) 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTest2()
        {
            var number = 1000;
            var expected = 500;
            var actual = number.PercentageOf( (Int64) 50 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentageOfTest3()
        {
            var number = 1000;
            var expected = 500;
            var actual = number.PercentageOf( new Decimal( 50 ) );

            Assert.AreEqual( expected, actual );
        }
    }
}