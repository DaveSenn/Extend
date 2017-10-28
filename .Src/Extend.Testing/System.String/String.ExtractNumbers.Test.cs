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
        public void ExtractNumbersTest()
        {
            var actual = "1a2b3c4".ExtractNumbers();
            Assert.Equal( "1234", actual );
        }

        [Fact]
        public void ExtractNumbersTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractNumbers( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}