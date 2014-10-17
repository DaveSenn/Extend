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
        public void ToMillisecondsTestCase ()
        {
            var number = 10.5;
            var expected = TimeSpan.FromMilliseconds( number );
            var actual = number.ToMilliseconds();

            Assert.AreEqual( expected, actual );
        }
    }
}