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
        public void AprilTestCase()
        {
            var expected = new DateTime( 2000, 4, 10 );
            var actual = 10.April( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}