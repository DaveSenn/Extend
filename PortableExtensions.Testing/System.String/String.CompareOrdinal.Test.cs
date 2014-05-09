#region Using

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void CompareOrdinalCaseTestCase()
        {
            var actual = "Test".CompareOrdinal( "Test" );
            Assert.IsTrue( actual );

            actual = "Test".CompareOrdinal( "test" );
            Assert.IsFalse( actual );

            actual = "Test".CompareOrdinal( "asdasd" );
            Assert.IsFalse( actual );
        }
    }
}