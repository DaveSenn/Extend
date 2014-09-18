#region Using

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [Test]
        public void RepeatTestCase()
        {
            var actual = 'a'.Repeat( 3 );
            Assert.AreEqual( "aaa", actual );
        }
    }
}