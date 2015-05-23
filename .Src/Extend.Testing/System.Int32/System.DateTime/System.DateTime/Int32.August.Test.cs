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
        public void AugustTestCase()
        {
            var expected = new DateTime( 2000, 8, 10 );
            var actual = 10.August( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}