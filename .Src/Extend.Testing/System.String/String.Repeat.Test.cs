#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void RepeatTest()
        {
            var actual = StringEx.Repeat( null, 10 );
            Assert.Equal( String.Empty, actual );
        }

        [Fact]
        public void RepeatTest1()
        {
            var actual = "".Repeat( 10 );
            Assert.Equal( String.Empty, actual );

            actual = "a".Repeat( 10 );
            Assert.Equal( "aaaaaaaaaa", actual );
        }

        [Fact]
        public void RepeatTest2()
        {
            var actual = "a".Repeat( 10 );
            Assert.Equal( "aaaaaaaaaa", actual );
        }

        [Fact]
        public void RepeatTest3()
        {
            var actual = "test".Repeat( 2 );
            Assert.Equal( "testtest", actual );
        }
    }
}