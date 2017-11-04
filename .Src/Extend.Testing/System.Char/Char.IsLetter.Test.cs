#region Usings

using System.Linq;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class CharExTest
    {
        [Fact]
        public void IsLetterTest()
        {
            var range = 0.RangeTo( 9 );
            foreach ( var c in range.Select( x => x.ToChar() ) )
                Assert.False( c.IsLetter() );

            Assert.True( 'a'.IsLetter() );
            Assert.True( 'A'.IsLetter() );
            Assert.True( 'z'.IsLetter() );
            Assert.False( '-'.IsLetter() );
        }
    }
}