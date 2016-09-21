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
        public void ToMinutesTest()
        {
            var number = 10.5;
            var expected = TimeSpan.FromMinutes( number );
            var actual = number.ToMinutes();

            Assert.AreEqual( expected, actual );
        }
    }
}