#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [Test]
        public void SeptemberTestCase ()
        {
            var expected = new DateTime( 2000, 9, 10 );
            var actual = Int16Ex.September( 10, 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}