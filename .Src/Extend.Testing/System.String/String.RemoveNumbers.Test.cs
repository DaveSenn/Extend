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
        public void RemoveNumbersTest()
        {
            var actual = "a1-b2.c3".RemoveNumbers();
            Assert.Equal( "a-b.c", actual );
        }

        [Fact]
        public void RemoveNumbersTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.RemoveNumbers( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}