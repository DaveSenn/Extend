#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void IfEmptyTest()
        {
            var actual = StringEx.IfNotEmpty( null, "test" );
            Assert.Equal( "test", actual );

            actual = "".IfNotEmpty( "test" );
            Assert.Equal( "test", actual );

            actual = "   ".IfNotEmpty( "test" );
            Assert.Equal( "test", actual );

            actual = "abc".IfNotEmpty( "test" );
            Assert.Equal( "abc", actual );
        }
    }
}