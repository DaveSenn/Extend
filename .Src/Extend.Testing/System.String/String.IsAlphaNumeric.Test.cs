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
        public void IsAlphaNumericTest()
        {
            var actual = "test".IsAlphaNumeric();
            Assert.True( actual );

            actual = "1test".IsAlphaNumeric();
            Assert.True( actual );

            actual = "1te-st".IsAlphaNumeric();
            Assert.False( actual );
        }

        [Fact]
        public void IsAlphaNumericTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.IsAlphaNumeric( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}