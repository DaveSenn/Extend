#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void MarchTestCase()
        {
            var expected = new DateTime( 2000, 3, 10 );
            var actual = 10.March( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}