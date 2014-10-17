#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DoubleExTest
    {
        [Test]
        public void IsNegativeInfinityTestCase ()
        {
            var number = 10.5;
            var expected = false;
            var actual = number.IsNegativeInfinity();

            Assert.AreEqual( expected, actual );

            number = Double.NegativeInfinity;
            expected = true;
            actual = number.IsNegativeInfinity();

            Assert.AreEqual( expected, actual );

            number = Double.PositiveInfinity;
            expected = false;
            actual = number.IsNegativeInfinity();

            Assert.AreEqual( expected, actual );
        }
    }
}