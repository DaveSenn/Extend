#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class CharExTest
    {
        [Fact]
        public void ToLowerTest()
        {
            Assert.Equal( 'a', 'A'.ToLower() );
            Assert.Equal( 'a', 'a'.ToLower() );
            Assert.Equal( '1', '1'.ToLower() );
        }
    }
}