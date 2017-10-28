#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int16ExTest
    {
        [Fact]
        public void FebruaryTest()
        {
            var expected = new DateTime( 2000, 2, 10 );
            var actual = Int16Ex.February( 10, 2000 );
            Assert.Equal( expected, actual );
        }
    }
}