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
        public void KeepLettersTest()
        {
            var actual = "a1b2c3".KeepLetters();
            Assert.Equal( "abc", actual );
        }

        [Fact]
        public void KeepLettersTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.KeepLetters( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}