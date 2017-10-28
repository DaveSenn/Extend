#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void JulyTest()
        {
            var expected = new DateTime( 2000, 7, 10 );
            var actual = 10.July( 2000 );
            Assert.Equal( expected, actual );
        }
    }
}