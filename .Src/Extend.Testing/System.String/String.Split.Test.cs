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
        public void SplitTest()
        {
            var actual = "1,2,3".Split( "," );
            Assert.Equal( 3, actual.Length );
            Assert.Equal( "1", actual[0] );
            Assert.Equal( "2", actual[1] );
            Assert.Equal( "3", actual[2] );
        }

        [Fact]
        public void SplitTest1()
        {
            var actual = "1,2,,3.4".Split( StringSplitOptions.RemoveEmptyEntries, ",", "." );
            Assert.Equal( 4, actual.Length );
            Assert.Equal( "1", actual[0] );
            Assert.Equal( "2", actual[1] );
            Assert.Equal( "3", actual[2] );
            Assert.Equal( "4", actual[3] );
        }

        [Fact]
        public void SplitTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Split( null, StringSplitOptions.RemoveEmptyEntries, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SplitTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Split( StringSplitOptions.RemoveEmptyEntries, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SplitTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Split( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SplitTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Split( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}