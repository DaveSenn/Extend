#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void JulyTest()
        {
            var expected = new DateTime( 2000, 7, 10 );
            var actual = 10.July( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}