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
        public void RemoveLettersTest()
        {
            var actual = "a1-b2.c3".RemoveLetters();
            Assert.Equal( "1-2.3", actual );
        }

        [Fact]
        public void RemoveLettersTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.RemoveLetters( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}