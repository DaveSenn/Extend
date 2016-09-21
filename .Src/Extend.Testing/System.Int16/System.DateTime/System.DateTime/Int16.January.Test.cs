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
        public void JanuaryTest()
        {
            var expected = new DateTime( 2000, 1, 10 );
            var actual = Int16Ex.January( 10, 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}