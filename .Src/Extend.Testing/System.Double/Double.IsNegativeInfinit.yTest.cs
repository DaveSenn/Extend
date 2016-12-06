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
        public void IsNegativeInfinityTest()
        {
            var number = 10.5;
            var actual = number.IsNegativeInfinity();

            Assert.AreEqual( false, actual );

            number = Double.NegativeInfinity;
            actual = number.IsNegativeInfinity();

            Assert.AreEqual( true, actual );

            number = Double.PositiveInfinity;
            actual = number.IsNegativeInfinity();

            Assert.AreEqual( false, actual );
        }
    }
}