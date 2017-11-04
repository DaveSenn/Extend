#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class CharExTest
    {
        [Fact]
        public void ToUpperTest()
        {
            Assert.Equal( 'A', 'A'.ToUpper() );
            Assert.Equal( 'A', 'a'.ToUpper() );
            Assert.Equal( '1', '1'.ToUpper() );
        }
    }
}