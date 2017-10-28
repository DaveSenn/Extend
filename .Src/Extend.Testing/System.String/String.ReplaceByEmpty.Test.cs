#region Usings

using System;
using FluentAssertions;
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

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ReplaceByEmptyTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".ReplaceByEmpty( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}