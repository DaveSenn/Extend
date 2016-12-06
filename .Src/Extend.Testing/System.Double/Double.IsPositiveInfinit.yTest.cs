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
            var actual = number.IsPositiveInfinity();

            Assert.AreEqual( false, actual );

            number = Double.NegativeInfinity;
            actual = number.IsPositiveInfinity();

            Assert.AreEqual( false, actual );

            number = Double.PositiveInfinity;
            actual = number.IsPositiveInfinity();

            Assert.AreEqual( true, actual );
        }
    }
}