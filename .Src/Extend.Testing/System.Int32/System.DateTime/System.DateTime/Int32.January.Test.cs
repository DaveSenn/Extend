#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void JanuaryTest()
        {
            var expected = new DateTime( 2000, 1, 10 );
            var actual = 10.January( 2000 );
            Assert.Equal( expected, actual );
        }
    }
}