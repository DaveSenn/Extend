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
        public void GetBeforeArgumentOutOfRangeTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetBefore( "test1", 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBeforeArgumentOutOfRangeTest2()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test test".GetBefore( "test", 2, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBeforeArgumentOutOfRangeTest3()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test test".GetBefore( "test", -2, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBeforeArgumentOutOfRangeTest4()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test test".GetBefore( "test", 2, -20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBeforeArgumentOutOfRangExceptionTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test".GetBefore( "test", 15 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBeforeCharArgumentOutOfRangeTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetBefore( 't', 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBeforeCharArgumentOutOfRangeTest2()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test test".GetBefore( 't', 2, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBeforeCharArgumentOutOfRangeTest3()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test test".GetBefore( 't', -2, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBeforeCharArgumentOutOfRangeTest4()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test test".GetBefore( 't', 2, -20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBeforeCharArgumentOutOfRangExceptionTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test".GetBefore( 't', 15 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBeforeCharTest()
        {
            var actual = "test test1".GetBefore( 's' );
            Assert.Equal( "te", actual );

            actual = "test test test".GetBefore( 's', 5 );
            Assert.Equal( "te", actual );
        }

        [Fact]
        public void GetBeforeCharTest1()
        {
            var actual = "test test1".GetBefore( 'e', 0, 4 );
            Assert.Equal( "t", actual );

            actual = "test test test".GetBefore( 'e', 3, 5 );
            Assert.Equal( "t t", actual );
        }

        [Fact]
        public void GetBeforeCharTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetBefore( null, 't', 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetBeforeCharTest2()
        {
            var actual = "test test1".GetBefore( 'a' );
            Assert.Equal( String.Empty, actual );
        }

        [Fact]
        public void GetBeforeCharTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetBefore( null, 't' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetBeforeTest()
        {
            var actual = "test test1".GetBefore( "test1" );
            Assert.Equal( "test ", actual );

            actual = "test test test".GetBefore( "test", 8 );
            Assert.Equal( "t ", actual );
        }

        [Fact]
        public void GetBeforeTest1()
        {
            var actual = "test test1".GetBefore( "test1", 0, 10 );
            Assert.Equal( "test ", actual );

            actual = "test test test".GetBefore( "test", 8, 6 );
            Assert.Equal( "t ", actual );
        }

        [Fact]
        public void GetBeforeTest1NullCheck()
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
        {
            Action test = () => StringEx.GetBefore( null, "", 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetBeforeTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetBefore( null, 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetBeforeTest2()
        {
            var actual = "test test1".GetBefore( "a", 0, 10 );
            Assert.Equal( String.Empty, actual );
        }

        [Fact]
        public void GetBeforeTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetBefore( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetBeforeTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetBefore( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}