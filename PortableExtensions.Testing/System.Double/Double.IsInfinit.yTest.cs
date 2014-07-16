#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DoubleExTest
    {
        [TestCase]
        public void IsInfinityTestCase()
        {
            var number = 10.5;
            var expected = false;
            var actual = number.IsInfinity();

            Assert.AreEqual( expected, actual );

            number = Double.NegativeInfinity;
            expected = true;
            actual = number.IsInfinity();

            Assert.AreEqual( expected, actual );

            number = Double.PositiveInfinity;
            expected = true;
            actual = number.IsInfinity();

            Assert.AreEqual( expected, actual );
        }
    }
}