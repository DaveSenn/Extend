#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [Test]
        public void AprilTestCase()
        {
            var expected = new DateTime( 2000, 4, 10 );
            var actual = Int16Ex.April( 10, 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}