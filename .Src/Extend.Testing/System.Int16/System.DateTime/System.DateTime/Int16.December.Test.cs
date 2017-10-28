#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int16ExTest
    {
        [Fact]
        public void DecemberTest()
        {
            var expected = new DateTime( 2000, 12, 10 );
            var actual = Int16Ex.December( 10, 2000 );
            Assert.Equal( expected, actual );
        }
    }
}