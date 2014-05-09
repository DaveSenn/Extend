#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [TestCase]
        public void OctoberTestCase()
        {
            var expected = new DateTime( 2000, 10, 10 );
            var actual = Int16Ex.October( 10, 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}