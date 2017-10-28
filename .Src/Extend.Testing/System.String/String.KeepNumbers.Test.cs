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
        public void KeepNumbersTest()
        {
            var actual = "a1b2c3".KeepNumbers();
            Assert.Equal( "123", actual );
        }

        [Fact]
        public void KeepNumbersTEstCaseNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.KeepNumbers( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}