#region Using

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void TruncateTestCase()
        {
            var actual = "testtest".Truncate( 7 );
            Assert.AreEqual( "test...", actual );

            actual = "testtest".Truncate( 7, "_-_" );
            Assert.AreEqual( "test_-_", actual );
        }
    }
}