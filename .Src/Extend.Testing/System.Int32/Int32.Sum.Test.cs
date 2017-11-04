#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void SumTest()
        {
            var actual = 10.Sum( 20, 30, 40, 50 );
            Assert.Equal( 150, actual );
        }

        [Fact]
        public void SumTest1()
        {
            var actual = ( 10 as Int32? ).Sum( 20, null, 40, null );
            Assert.Equal( 70, actual );

            actual = ( null as Int32? ).Sum( new Int32?[]
            {
                null,
                null
            } );
            Assert.Equal( 0, actual );
        }

        [Fact]
        public void SumTest1NullCheck()
        {
            Int32?[] values = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ( 10 as Int32? ).Sum( values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SumTest2()
        {
            var actual = "test".Sum( x => x.Length, "a", "b", "c", "d" );
            Assert.Equal( 8, actual );

            actual = "".Sum( x => x.Length, "a", "b", "c", "d" );
            Assert.Equal( 4, actual );
        }

        [Fact]
        public void SumTest2NullCheck()
        {
            String[] values = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "Test".Sum( x => x.Length, values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SumTest2NullCheck2()
        {
            Func<String, Int32> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "Test".Sum( func, "test", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SumTest3()
        {
            var actual = "test".Sum( x => x.Length > 1 ? (Int32?) x.Length : null, "a", "b", "c", "d" );
            Assert.Equal( 4, actual );

            actual = "test".Sum( x => x.Length > 1 ? (Int32?) x.Length : null, "aaaa", "b", "c", "d" );
            Assert.Equal( 8, actual );
        }

        [Fact]
        public void SumTest3NullCheck()
        {
            String[] values = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "Test".Sum( x => (Int32?) x.Length, values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SumTest3NullCheck2()
        {
            Func<String, Int32?> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "Test".Sum( func, "test", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SumTestNullCheck()
        {
            Int32[] values = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => 10.Sum( values );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}