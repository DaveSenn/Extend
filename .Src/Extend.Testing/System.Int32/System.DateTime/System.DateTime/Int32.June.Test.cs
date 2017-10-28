#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void JuneTest()
        {
            var expected = new DateTime( 2000, 6, 10 );
            var actual = 10.June( 2000 );
            Assert.Equal( expected, actual );
        }
    }
}