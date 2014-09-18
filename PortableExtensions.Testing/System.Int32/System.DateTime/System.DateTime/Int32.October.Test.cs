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
        public void OctoberTestCase()
        {
            var expected = new DateTime( 2000, 10, 10 );
            var actual = 10.October( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}