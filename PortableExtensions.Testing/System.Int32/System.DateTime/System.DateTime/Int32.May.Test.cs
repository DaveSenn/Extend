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
        public void MayTestCase()
        {
            var expected = new DateTime( 2000, 5, 10 );
            var actual = 10.May( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}