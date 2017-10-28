#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class CharExTest
    {
        [Fact]
        public void IsLowerTest()
        {
            Assert.True( 'a'.IsLower() );
            Assert.False( 'A'.IsLower() );
            Assert.False( '1'.IsLower() );
        }
    }
}