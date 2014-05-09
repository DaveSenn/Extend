#region Using

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [TestCase]
        public void IsWhiteSpaceTestCase()
        {
            Assert.IsFalse( 'a'.IsWhiteSpace() );
            Assert.IsFalse( 'A'.IsWhiteSpace() );
            Assert.IsFalse( 'z'.IsWhiteSpace() );
            Assert.IsFalse( '-'.IsWhiteSpace() );
            Assert.IsTrue( ' '.IsWhiteSpace() );
        }
    }
}