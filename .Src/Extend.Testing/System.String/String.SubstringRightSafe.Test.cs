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
        public void SubstringRightSafeTest()
        {
            var actual = "testabc".SubstringRightSafe( 3 );
            Assert.Equal( "abc", actual );

            actual = "testabc".SubstringRightSafe( 300 );
            Assert.Equal( "testabc", actual );

            actual = "".SubstringRightSafe( 300 );
            Assert.Equal( "", actual );
        }

        [Fact]
        public void SubstringRightSafeTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.SubstringRight( null, 5 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}