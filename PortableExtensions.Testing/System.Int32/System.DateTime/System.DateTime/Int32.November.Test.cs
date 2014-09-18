#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void NovemberTestCase()
        {
            var expected = new DateTime( 2000, 11, 10 );
            var actual = 10.November( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}