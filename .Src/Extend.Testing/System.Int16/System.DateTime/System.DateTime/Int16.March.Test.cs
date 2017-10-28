#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int16ExTest
    {
        [Fact]
        public void MarchTest()
        {
            var expected = new DateTime( 2000, 3, 10 );
            var actual = Int16Ex.March( 10, 2000 );
            Assert.Equal( expected, actual );
        }
    }
}