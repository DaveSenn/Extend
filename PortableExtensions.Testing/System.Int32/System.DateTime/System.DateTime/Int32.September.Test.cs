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
        public void SeptemberTestCase()
        {
            var expected = new DateTime( 2000, 9, 10 );
            var actual = 10.September( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}