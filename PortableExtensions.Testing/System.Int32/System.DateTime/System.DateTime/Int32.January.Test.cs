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
        public void JanuaryTestCase()
        {
            var expected = new DateTime( 2000, 1, 10 );
            var actual = 10.January( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}