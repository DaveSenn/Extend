#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void SeptemberTest()
        {
            var expected = new DateTime( 2000, 9, 10 );
            var actual = 10.September( 2000 );
            Assert.Equal( expected, actual );
        }
    }
}