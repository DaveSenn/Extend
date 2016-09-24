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
        public void ToMillisecondsTest()
        {
            const Double number = 10.5;
            var expected = TimeSpan.FromMilliseconds( number );
            var actual = number.ToMilliseconds();

            Assert.AreEqual( expected, actual );
        }
    }
}