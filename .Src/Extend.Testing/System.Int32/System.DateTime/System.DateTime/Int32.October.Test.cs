#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void OctoberTest()
        {
            var expected = new DateTime( 2000, 10, 10 );
            var actual = 10.October( 2000 );
            Assert.Equal( expected, actual );
        }
    }
}