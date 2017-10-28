#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int16ExTest
    {
        [Fact]
        public void AugustTest()
        {
            var expected = new DateTime( 2000, 8, 10 );
            var actual = Int16Ex.August( 10, 2000 );
            Assert.Equal( expected, actual );
        }
    }
}