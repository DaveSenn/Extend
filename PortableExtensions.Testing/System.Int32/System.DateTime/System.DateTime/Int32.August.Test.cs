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
        public void AugustTestCase()
        {
            var expected = new DateTime( 2000, 8, 10 );
            var actual = 10.August( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}