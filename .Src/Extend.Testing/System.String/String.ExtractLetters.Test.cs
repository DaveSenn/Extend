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
        public void ExtractLettersTest()
        {
            var actual = "1a2b3c4".ExtractLetters();
            Assert.Equal( "abc", actual );
        }

        [Fact]
        public void ExtractLettersTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractLetters( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}