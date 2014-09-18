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
        public void MarchTestCase()
        {
            var expected = new DateTime( 2000, 3, 10 );
            var actual = Int16Ex.March( 10, 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}