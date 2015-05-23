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
        public void ToSecondsTestCase()
        {
            var number = 10.5;
            var expected = TimeSpan.FromSeconds( number );
            var actual = number.ToSeconds();

            Assert.AreEqual( expected, actual );
        }
    }
}