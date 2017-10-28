#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int16ExTest
    {
        [Fact]
        public void JanuaryTest()
        {
            var expected = new DateTime( 2000, 1, 10 );
            var actual = Int16Ex.January( 10, 2000 );
            Assert.Equal( expected, actual );
        }
    }
}