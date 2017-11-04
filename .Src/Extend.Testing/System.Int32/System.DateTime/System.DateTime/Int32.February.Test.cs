#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void FebruaryTest()
        {
            var expected = new DateTime( 2000, 2, 10 );
            var actual = 10.February( 2000 );
            Assert.Equal( expected, actual );
        }
    }
}