#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [Test]
        public void IsUpperTest()
        {
            Assert.IsFalse( 'a'.IsUpper() );
            Assert.IsTrue( 'A'.IsUpper() );
            Assert.IsFalse( '1'.IsUpper() );
        }
    }
}