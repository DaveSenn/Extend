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
        public void IsNaNTest()
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