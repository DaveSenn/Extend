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
        public void KeepLettersAndNumbersTest()
        {
            var actual = "a1b2c3".KeepLettersAndNumbers();
            Assert.Equal( "a1b2c3", actual );

            actual = "a1.b2-c3".KeepLettersAndNumbers();
            Assert.Equal( "a1b2c3", actual );
        }

        [Fact]
        public void KeepLettersAndNumbersTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.KeepLettersAndNumbers( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}