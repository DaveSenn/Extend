#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void AprilTest()
        {
            var expected = new DateTime( 2000, 4, 10 );
            var actual = 10.April( 2000 );
            Assert.Equal( expected, actual );
        }
    }
}