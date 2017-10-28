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
        public void RemoveLettersAndNumbersTest()
        {
            var actual = "a1-b2.c3".RemoveLettersAndNumbers();
            Assert.Equal( "-.", actual );
        }

        [Fact]
        public void RemoveLettersAndNumbersTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.RemoveLettersAndNumbers( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}