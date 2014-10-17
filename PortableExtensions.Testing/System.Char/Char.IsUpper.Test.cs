#region Usings

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [Test]
        public void IsUpperTestCase ()
        {
            Assert.IsFalse( 'a'.IsUpper() );
            Assert.IsTrue( 'A'.IsUpper() );
            Assert.IsFalse( '1'.IsUpper() );
        }
    }
}