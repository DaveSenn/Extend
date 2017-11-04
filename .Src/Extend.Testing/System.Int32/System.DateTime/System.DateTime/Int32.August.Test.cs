#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void AugustTest()
        {
            var expected = new DateTime( 2000, 8, 10 );
            var actual = 10.August( 2000 );
            Assert.Equal( expected, actual );
        }
    }
}