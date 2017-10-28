#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void NovemberTest()
        {
            var expected = new DateTime( 2000, 11, 10 );
            var actual = 10.November( 2000 );
            Assert.Equal( expected, actual );
        }
    }
}