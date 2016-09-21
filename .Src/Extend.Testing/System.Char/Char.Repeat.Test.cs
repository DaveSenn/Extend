#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [Test]
        public void RepeatTest()
        {
            var actual = 'a'.Repeat( 3 );
            Assert.AreEqual( "aaa", actual );
        }
    }
}