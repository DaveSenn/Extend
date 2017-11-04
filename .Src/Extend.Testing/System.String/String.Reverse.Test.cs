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
        public void ReverseTest()
        {
            var actual = "abc".Reverse();
            Assert.Equal( "cba", actual );
        }

        [Fact]
        public void ReverseTest1()
        {
            var actual = "a".Reverse();
            Assert.Equal( "a", actual );
        }

        [Fact]
        public void ReverseTest2()
        {
            var actual = "".Reverse();
            Assert.Equal( "", actual );
        }

        [Fact]
        public void ReverseTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Reverse( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}