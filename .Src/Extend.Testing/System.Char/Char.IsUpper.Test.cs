#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class CharExTest
    {
        [Fact]
        public void IsUpperTest()
        {
            Assert.False( 'a'.IsUpper() );
            Assert.True( 'A'.IsUpper() );
            Assert.False( '1'.IsUpper() );
        }
    }
}