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
        public void GetBetweenArgumentOutOfRangeTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "121test2".GetBetween( "1", "2", 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBetweenArgumentOutOfRangeTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "1test2".GetBetween( "1", "2", 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBetweenArgumentOutOfRangeTest2()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "121test2".GetBetween( "1", "2", 2, 60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBetweenArgumentOutOfRangeTest3()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "121test2".GetBetween( "1", "2", -2, 60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBetweenArgumentOutOfRangeTest4()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "121test2".GetBetween( "1", "2", 2, -60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBetweenCharArgumentOutOfRangeTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "121test2".GetBetween( '1', '2', 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBetweenCharArgumentOutOfRangeTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "1test2".GetBetween( '1', '2', 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBetweenCharArgumentOutOfRangeTest2()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "121test2".GetBetween( '1', '2', 2, 60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBetweenCharArgumentOutOfRangeTest3()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "121test2".GetBetween( '1', '2', -2, 60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBetweenCharArgumentOutOfRangeTest4()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "121test2".GetBetween( '1', '2', 2, -60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetBetweenCharTest()
        {
            var actual = "1test2".GetBetween( '1', '2' );
            Assert.Equal( "test", actual );

            actual = "121test2".GetBetween( '1', '2', 2 );
            Assert.Equal( "test", actual );
        }

        [Fact]
        public void GetBetweenCharTest1()
        {
            var actual = "1test2".GetBetween( '1', '2', 0, 6 );
            Assert.Equal( "test", actual );

            actual = "121test2".GetBetween( '1', '2', 2, 6 );
            Assert.Equal( "test", actual );
        }

        [Fact]
        public void GetBetweenCharTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetBetween( null, 't', 't' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetBetweenCharTest2()
        {
            var actual = "1test2".GetBetween( 'a', '2' );
            Assert.Equal( String.Empty, actual );
        }

        [Fact]
        public void GetBetweenCharTest3()
        {
            var actual = "1test2".GetBetween( 't', 'b' );
            Assert.Equal( String.Empty, actual );
        }

        [Fact]
        public void GetBetweenCharTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetBetween( null, 't', 't' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetBetweenTest()
        {
            var actual = "1test2".GetBetween( "1", "2" );
            Assert.Equal( "test", actual );

            actual = "121test2".GetBetween( "1", "2", 2 );
            Assert.Equal( "test", actual );
        }

        [Fact]
        public void GetBetweenTest1()
        {
            var actual = "1test2".GetBetween( "1", "2", 0, 6 );
            Assert.Equal( "test", actual );

            actual = "121test2".GetBetween( "1", "2", 2, 6 );
            Assert.Equal( "test", actual );
        }

        [Fact]
        public void GetBetweenTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetBetween( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetBetweenTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetBetween( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetBetweenTest1NullCheck2()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetBetween( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetBetweenTest2()
        {
            var actual = "1test2".GetBetween( "1", "a" );
            Assert.Equal( String.Empty, actual );
        }

        [Fact]
        public void GetBetweenTest3()
        {
            var actual = "1test2".GetBetween( "a", "t" );
            Assert.Equal( String.Empty, actual );
        }

        [Fact]
        public void GetBetweenTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetBetween( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetBetweenTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetBetween( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetBetweenTestNullCheck2()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetBetween( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}