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
        public void JulyTestCase()
        {
            var expected = new DateTime( 2000, 7, 10 );
            var actual = Int16Ex.July( 10, 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}