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
        public void FebruaryTestCase()
        {
            var expected = new DateTime( 2000, 2, 10 );
            var actual = Int16Ex.February( 10, 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}