#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class RandomValueExTest
    {
        [Fact]
        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
        public void GetRandomBooleanTest() => RandomValueEx.GetRandomBoolean();

        [Fact]
        public void GetRandomByteTest()
        {
            // ReSharper disable once UnusedVariable
            var actual = RandomValueEx.GetRandomByte();
            Assert.True( true );
        }

        [Fact]
        public void GetRandomCharTest()
        {
            var actual = RandomValueEx.GetRandomChar();
            actual.Should()
                  .NotBeNull();
        }

        [Fact]
        public void GetRandomDateTimeTest()
        {
            var min = DateTime.Now.Subtract( 1.ToDays() );

            for ( var i = 0; i < 10000; i++ )
            {
                var max = DateTime.Now.AddDays( i );

                var actual = RandomValueEx.GetRandomDateTime( min, max );
                Assert.True( actual >= min && actual <= max );
            }
        }

        [Fact]
        public void GetRandomDateTimeTest2()
        {
            for ( var i = 0; i < 1000; i++ )
            {
                var actual = RandomValueEx.GetRandomDateTime();
                Assert.True( actual >= new DateTime( 1753, 01, 01 ) && actual <= new DateTime( 9999, 12, 31 ) );
            }
        }

        [Fact]
        public void GetRandomDateTimeTest3()
        {
            var min = DateTime.Now.Subtract( 1.ToDays() );
            for ( var i = 0; i < 10000; i++ )
            {
                var actual = RandomValueEx.GetRandomDateTime( min );
                Assert.True( actual >= min && actual <= new DateTime( 9999, 12, 31 ) );
            }
        }

        [Fact]
        public void GetRandomDateTimeTest4()
        {
            var max = DateTime.Now.AddDays( 100 );
            for ( var i = 0; i < 10000; i++ )
            {
                var actual = RandomValueEx.GetRandomDateTime( max: max );
                Assert.True( actual >= new DateTime( 1753, 01, 01 ) && actual <= max );
            }
        }

        [Fact]
        public void GetRandomDoubleTest()
        {
            var actual = RandomValueEx.GetRandomDouble( -100, 300 );
            actual.Should()
                  .BeGreaterOrEqualTo( -100 );
            actual.Should()
                  .BeLessThan( 300 );
        }

        [Fact]
        public void GetRandomDoubleTestArgumentOutOfRangeException()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => RandomValueEx.GetRandomDouble( 30, 20 );
            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetRandomEnumINvalidTypeTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => RandomValueEx.GetRandomEnum<Int32>();

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
        public void GetRandomEnumTest() => RandomValueEx.GetRandomEnum<DayOfWeek>();

        [Fact]
        public void GetRandomInt16Test()
        {
            var actual = RandomValueEx.GetRandomInt16( 10, 20 );
            Assert.True( actual >= 10, "To small" );
            Assert.True( actual < 20, "To big" );
        }

        [Fact]
        public void GetRandomInt16TestArgumentOutOfRangeException()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => RandomValueEx.GetRandomInt16( 30, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetRandomInt32Test()
        {
            var actual = RandomValueEx.GetRandomInt32( 10, 20 );
            Assert.True( actual >= 10, "To small" );
            Assert.True( actual < 20, "To big" );
        }

        [Fact]
        public void GetRandomInt32TestArgumentOutOfRangeException()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => RandomValueEx.GetRandomInt32( 30, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetRandomInt64Test()
        {
            var actual = RandomValueEx.GetRandomInt64( 10, 20 );
            Assert.True( actual >= 10, "To small" );
            Assert.True( actual < 20, "To big" );
        }

        [Fact]
        public void GetRandomInt64TestArgumentOutOfRangeException()
        {
            Action test = () => RandomValueEx.GetRandomInt64( 20, 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GetRandomStringsTest()
        {
            var actual = RandomValueEx.GetRandomStrings( 100 );
            Assert.Equal( 100, actual.Count );
            actual.ForEach( x => Assert.True( x.Length > 0 ) );
        }

        [Fact]
        public void GetRandomStringTest()
        {
            var actual = RandomValueEx.GetRandomString();
            Assert.True( actual.Length > 0 );
        }
    }
}