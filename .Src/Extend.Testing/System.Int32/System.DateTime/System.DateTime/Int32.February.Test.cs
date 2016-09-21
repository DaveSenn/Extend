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
        public void FebruaryTest()
        {
            var expected = new DateTime( 2000, 2, 10 );
            var actual = 10.February( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}