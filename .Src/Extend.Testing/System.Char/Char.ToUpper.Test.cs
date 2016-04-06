#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [Test]
        public void ToUpperTest()
        {
            Assert.AreEqual( 'A', 'A'.ToUpper() );
            Assert.AreEqual( 'A', 'a'.ToUpper() );
            Assert.AreEqual( '1', '1'.ToUpper() );
        }
    }
}