#region Using

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [TestCase]
        public void ToUpperTestCase()
        {
            Assert.AreEqual( 'A', 'A'.ToUpper() );
            Assert.AreEqual( 'A', 'a'.ToUpper() );
            Assert.AreEqual( '1', '1'.ToUpper() );
        }
    }
}