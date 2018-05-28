#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void ReplaceByEmptyTest()
        {
            var actual = "abcd".ReplaceByEmpty( "a", "c" );
            Assert.Equal( "bd", actual );
        }

        [Fact]
        public void ReplaceByEmptyTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ReplaceByEmpty( null, "a", "c" );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ReplaceByEmptyTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".ReplaceByEmpty( null );

            Assert.Throws<ArgumentNullException>( test );
        }
    }
}