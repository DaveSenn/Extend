#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [Test]
        public void IsLowerTest()
        {
            Assert.IsTrue( 'a'.IsLower() );
            Assert.IsFalse( 'A'.IsLower() );
            Assert.IsFalse( '1'.IsLower() );
        }
    }
}