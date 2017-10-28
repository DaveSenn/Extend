#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void DecemberTest()
        {
            var expected = new DateTime( 2000, 12, 10 );
            var actual = 10.December( 2000 );
            Assert.Equal( expected, actual );
        }
    }
}