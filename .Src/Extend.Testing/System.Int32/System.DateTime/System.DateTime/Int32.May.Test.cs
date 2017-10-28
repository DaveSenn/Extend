#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void MayTest()
        {
            var expected = new DateTime( 2000, 5, 10 );
            var actual = 10.May( 2000 );
            Assert.Equal( expected, actual );
        }
    }
}