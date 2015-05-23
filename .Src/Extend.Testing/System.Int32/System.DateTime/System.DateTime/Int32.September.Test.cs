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
        public void SeptemberTestCase()
        {
            var expected = new DateTime( 2000, 9, 10 );
            var actual = 10.September( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}