#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DoubleExTest
    {
        [Fact]
        public void SumTest()
        {
            var actual = 10.1d.Sum( 20.1, 30.1, 40.1, 50.1 );
            Assert.Equal( 150.5, actual );
        }

        [Fact]
        public void SumTest1()
        {
            var actual = ( 10.5 as Double? ).Sum( 20.5, null, 40.5, null );
            Assert.Equal( 71.5, actual );

            actual = ( null as Double? ).Sum( new Double?[]
            {
                null,
                null
            } );
            Assert.Equal( 0d, actual );
        }

        [Fact]
        public void SumTest1NullCheck()
        {
            Double?[] values = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ( 10d as Double? ).Sum( values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SumTest2()
        {
            var actual = "test".Sum( x => (Double) x.Length, "a", "b", "c", "d" );
            Assert.Equal( 8d, actual );

            actual = "".Sum( x => x.Length, "a", "b", "c", "d" );
            Assert.Equal( 4d, actual );
        }

        [Fact]
        public void SumTest2NullCheck()
        {
            String[] values = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "Test".Sum( x => (Double) x.Length, values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SumTest2NullCheck2()
        {
            Func<String, Double> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "Test".Sum( func, "test", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SumTest3()
        {
            var actual = "test".Sum( x => x.Length > 1d ? (Double?) x.Length : null, "a", "b", "c", "d" );
            Assert.Equal( 4d, actual );

            actual = "test".Sum( x => x.Length > 1d ? (Double?) x.Length : null, "aaaa", "b", "c", "d" );
            Assert.Equal( 8d, actual );
        }

        [Fact]
        public void SumTest3NullCheck()
        {
            String[] values = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "Test".Sum( x => (Double?) x.Length, values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SumTest3NullCheck2()
        {
            Func<String, Double?> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "Test".Sum( func, "test", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SumTestNullCheck()
        {
            Double[] values = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => 10.1.Sum( values );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}