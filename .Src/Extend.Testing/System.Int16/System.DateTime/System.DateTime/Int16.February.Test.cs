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
        public void FebruaryTest()
        {
            var expected = new DateTime( 2000, 2, 10 );
            var actual = Int16Ex.February( 10, 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}