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
        public void SubstringLeftSafeTest()
        {
            var actual = "testabc".SubstringLeftSafe( 4 );
            Assert.Equal( "test", actual );

            actual = "testabc".SubstringLeftSafe( 400 );
            Assert.Equal( "testabc", actual );

            actual = "".SubstringLeftSafe( 4 );
            Assert.Equal( "", actual );
        }

        [Fact]
        public void SubstringLeftSafeTest1()
        {
            var actual = "123test123".SubstringLeftSafe( 3, 4 );
            Assert.Equal( "test", actual );

            actual = "testabc".SubstringLeftSafe( 0, 400 );
            Assert.Equal( "testabc", actual );

            actual = "123tes".SubstringLeftSafe( 3, 4 );
            Assert.Equal( "tes", actual );

            actual = "".SubstringLeftSafe( 0, 4 );
            Assert.Equal( "", actual );

            actual = "".SubstringLeftSafe( 2, 4 );
            Assert.Equal( "", actual );
        }

        [Fact]
        public void SubstringLeftSafeTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.SubstringLeftSafe( null, 1, 5 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SubstringLeftSafeTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.SubstringLeftSafe( null, 5 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}