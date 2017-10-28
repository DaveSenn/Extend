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
        public void GetAfteOverloadrArgumentOutOfRangeTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( 't', 4, 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetAfterArgumentOutOfRangeTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( "test", 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetAfterArgumentOutOfRangeTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( "test", 4, 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetAfterArgumentOutOfRangeTest2()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( "test", 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetAfterArgumentOutOfRangeTest3()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( "test", -1, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetAfterArgumentOutOfRangeTest4()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( "test", 20, -2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetAfterOverloadArgumentOutOfRangeTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( 't', 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetAfterOverloadArgumentOutOfRangeTest2()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( 't', 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetAfterOverloadTest()
        {
            var actual = "test test1".GetAfter( 's' );
            Assert.Equal( "t test1", actual );

            actual = "test test1".GetAfter( "t", 5 );
            Assert.Equal( "est1", actual );
        }

        [Fact]
        public void GetAfterOverloadTest1()
        {
            var actual = "test test1".GetAfter( 'e', 0, 6 );
            Assert.Equal( "st t", actual );

            actual = "test test1".GetAfter( 't', 2, 8 );
            Assert.Equal( " test1", actual );
        }

        [Fact]
        public void GetAfterOverloadTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetAfter( null, 't', 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetAfterOverloadTest2()
        {
            var actual = "test test1".GetAfter( 'a' );
            Assert.Equal( String.Empty, actual );
        }

        [Fact]
        public void GetAfterOverloadTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetAfter( null, 't' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetAfterTest()
        {
            var actual = "test test1".GetAfter( "test" );
            Assert.Equal( " test1", actual );

            actual = "test test1".GetAfter( "test", 2 );
            Assert.Equal( "1", actual );
        }

        [Fact]
        public void GetAfterTest1()
        {
            var actual = "test test1".GetAfter( "test", 0, 10 );
            Assert.Equal( " test1", actual );

            actual = "test test1".GetAfter( "test", 2, 8 );
            Assert.Equal( "1", actual );
        }

        [Fact]
        public void GetAfterTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetAfter( null, "", 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetAfterTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetAfter( null, 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetAfterTest2()
        {
            var actual = "test123456789".GetAfter( "a", 0, 10 );
            Assert.Equal( String.Empty, actual );
        }

        [Fact]
        public void GetAfterTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetAfter( null, "test" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetAfterTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetAfter( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}