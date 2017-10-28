#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class CharExTest
    {
        [Fact]
        public void RepeatTest()
        {
            var actual = 'a'.Repeat( 3 );
            Assert.Equal( "aaa", actual );
        }
    }
}