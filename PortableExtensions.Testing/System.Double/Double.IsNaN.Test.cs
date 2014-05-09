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
        public void IsNaNTestCase()
        {
            var number = 10.5;
            var expected = false;
            var actual = number.IsNaN();

            Assert.AreEqual( expected, actual );

            number = Double.NaN;
            expected = true;
            actual = number.IsNaN();

            Assert.AreEqual( expected, actual );
        }
    }
}