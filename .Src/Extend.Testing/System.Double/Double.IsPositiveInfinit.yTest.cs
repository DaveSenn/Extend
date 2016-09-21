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
        public void IsPositiveInfinityTest()
        {
            var number = 10.5;
            var expected = false;
            var actual = number.IsPositiveInfinity();

            Assert.AreEqual( expected, actual );

            number = Double.NegativeInfinity;
            expected = false;
            actual = number.IsPositiveInfinity();

            Assert.AreEqual( expected, actual );

            number = Double.PositiveInfinity;
            expected = true;
            actual = number.IsPositiveInfinity();

            Assert.AreEqual( expected, actual );
        }
    }
}