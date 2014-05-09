#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [TestCase]
        public void JulyTestCase()
        {
            var expected = new DateTime( 2000, 7, 10 );
            var actual = 10.July( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}