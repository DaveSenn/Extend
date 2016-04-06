#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [Test]
        public void AprilTest()
        {
            var expected = new DateTime( 2000, 4, 10 );
            var actual = Int16Ex.April( 10, 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}