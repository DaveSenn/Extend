#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class CharExTest
    {
        [Fact]
        public void IsWhiteSpaceTest()
        {
            Assert.False( 'a'.IsWhiteSpace() );
            Assert.False( 'A'.IsWhiteSpace() );
            Assert.False( 'z'.IsWhiteSpace() );
            Assert.False( '-'.IsWhiteSpace() );
            Assert.True( ' '.IsWhiteSpace() );
        }
    }
}