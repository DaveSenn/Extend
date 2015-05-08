#region Usings

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void IfEmptyTestCase()
        {
            var actual = StringEx.IfNotEmpty( null, "test" );
            Assert.AreEqual( "test", actual );

            actual = "".IfNotEmpty( "test" );
            Assert.AreEqual( "test", actual );

            actual = "   ".IfNotEmpty( "test" );
            Assert.AreEqual( "test", actual );

            actual = "abc".IfNotEmpty( "test" );
            Assert.AreEqual( "abc", actual );
        }
    }
}