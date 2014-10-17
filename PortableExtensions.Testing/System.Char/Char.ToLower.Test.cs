#region Usings

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [Test]
        public void ToLowerTestCase ()
        {
            Assert.AreEqual( 'a', 'A'.ToLower() );
            Assert.AreEqual( 'a', 'a'.ToLower() );
            Assert.AreEqual( '1', '1'.ToLower() );
        }
    }
}