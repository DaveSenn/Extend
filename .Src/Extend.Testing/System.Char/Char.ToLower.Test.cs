#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [Test]
        public void ToLowerTest()
        {
            Assert.AreEqual( 'a', 'A'.ToLower() );
            Assert.AreEqual( 'a', 'a'.ToLower() );
            Assert.AreEqual( '1', '1'.ToLower() );
        }
    }
}