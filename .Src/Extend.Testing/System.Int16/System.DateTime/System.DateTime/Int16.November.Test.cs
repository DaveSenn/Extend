#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int16ExTest
    {
        [Fact]
        public void NovemberTest()
        {
            var expected = new DateTime( 2000, 11, 10 );
            var actual = Int16Ex.November( 10, 2000 );
            Assert.Equal( expected, actual );
        }
    }
}