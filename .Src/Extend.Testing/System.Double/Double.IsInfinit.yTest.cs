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
        public void IsInfinityTest()
        {
            var number = 10.5;
            var actual = number.IsInfinity();

            Assert.AreEqual( false, actual );

            number = Double.NegativeInfinity;
            actual = number.IsInfinity();

            Assert.AreEqual( true, actual );

            number = Double.PositiveInfinity;
            actual = number.IsInfinity();

            Assert.AreEqual( true, actual );
        }
    }
}