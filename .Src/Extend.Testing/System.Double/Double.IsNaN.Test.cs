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
            var actual = number.IsNaN();

            Assert.AreEqual( false, actual );

            number = Double.NaN;
            actual = number.IsNaN();

            Assert.AreEqual( true, actual );
        }
    }
}