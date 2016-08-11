#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class DoubleExTest
    {
        [Test]
        public void PercentOfTest()
        {
            Double number = 1000;
            var expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTest1()
        {
            Double number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Double) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTest2()
        {
            Double number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }
    }
}