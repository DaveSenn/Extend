#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int16ExTest
    {
        [Fact]
        public void JulyTest()
        {
            var expected = new DateTime( 2000, 7, 10 );
            var actual = Int16Ex.July( 10, 2000 );
            Assert.Equal( expected, actual );
        }
    }
}