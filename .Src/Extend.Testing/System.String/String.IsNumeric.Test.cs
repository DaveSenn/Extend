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
        public void IsNumericTest()
        {
            var actual = "test".IsNumeric();
            Assert.False( actual );

            actual = "1test".IsNumeric();
            Assert.False( actual );

            actual = "123".IsNumeric();
            Assert.True( actual );
        }

        [Fact]
        public void IsNumericTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.IsNumeric( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}