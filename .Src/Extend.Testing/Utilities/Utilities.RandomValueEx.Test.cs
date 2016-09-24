#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class RandomValueExTest
    {
        [Test]
        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
        public void GetRandomBooleanTest() => RandomValueEx.GetRandomBoolean();

        [Test]
        public void GetRandomByteTest()
        {
            // ReSharper disable once UnusedVariable
            var actual = RandomValueEx.GetRandomByte();
            Assert.IsTrue( true );
        }

        [Test]
        public void GetRandomCharTest()
        {
            var actual = RandomValueEx.GetRandomChar();
            actual.Should()
                  .NotBeNull();
        }

        [Test]
        public void GetRandomDateTimeTest()
        {
            var min = DateTime.Now.Subtract( 1.ToDays() );

            for ( var i = 0; i < 10000; i++ )
            {
                var max = DateTime.Now.AddDays( i );

                var actual = RandomValueEx.GetRandomDateTime( min, max );
                Assert.IsTrue( actual >= min && actual <= max );
            }
        }

        [Test]
        public void GetRandomDateTimeTest2()
        {
            for ( var i = 0; i < 1000; i++ )
            {
                var actual = RandomValueEx.GetRandomDateTime();
                Assert.IsTrue( actual >= new DateTime( 1753, 01, 01 ) && actual <= new DateTime( 9999, 12, 31 ) );
            }
        }

        [Test]
        public void GetRandomDateTimeTest3()
        {
            var min = DateTime.Now.Subtract( 1.ToDays() );
            for ( var i = 0; i < 10000; i++ )
            {
                var actual = RandomValueEx.GetRandomDateTime( min );
                Assert.IsTrue( actual >= min && actual <= new DateTime( 9999, 12, 31 ) );
            }
        }

        [Test]
        public void GetRandomDateTimeTest4()
        {
            var max = DateTime.Now.AddDays( 100 );
            for ( var i = 0; i < 10000; i++ )
            {
                var actual = RandomValueEx.GetRandomDateTime( max: max );
                Assert.IsTrue( actual >= new DateTime( 1753, 01, 01 ) && actual <= max );
            }
        }

        [Test]
        public void GetRandomDoubleTest()
        {
            var actual = RandomValueEx.GetRandomDouble( -100, 300 );
            actual.Should()
                  .BeGreaterOrEqualTo( -100 );
            actual.Should()
                  .BeLessThan( 300 );
        }

        [Test]
        public void GetRandomDoubleTestArgumentOutOfRangeException()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => RandomValueEx.GetRandomDouble( 30, 20 );
            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetRandomEnumINvalidTypeTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => RandomValueEx.GetRandomEnum<Int32>();

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
        public void GetRandomEnumTest() => RandomValueEx.GetRandomEnum<DayOfWeek>();

        [Test]
        public void GetRandomInt16Test()
        {
            var actual = RandomValueEx.GetRandomInt16( 10, 20 );
            Assert.IsTrue( actual >= 10, "To small" );
            Assert.IsTrue( actual < 20, "To big" );
        }

        [Test]
        public void GetRandomInt16TestArgumentOutOfRangeException()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => RandomValueEx.GetRandomInt16( 30, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetRandomInt32Test()
        {
            var actual = RandomValueEx.GetRandomInt32( 10, 20 );
            Assert.IsTrue( actual >= 10, "To small" );
            Assert.IsTrue( actual < 20, "To big" );
        }

        [Test]
        public void GetRandomInt32TestArgumentOutOfRangeException()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => RandomValueEx.GetRandomInt32( 30, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetRandomInt64Test()
        {
            var actual = RandomValueEx.GetRandomInt64( 10, 20 );
            Assert.IsTrue( actual >= 10, "To small" );
            Assert.IsTrue( actual < 20, "To big" );
        }

        [Test]
        public void GetRandomInt64TestArgumentOutOfRangeException()
        {
            Action test = () => RandomValueEx.GetRandomInt64( 20, 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetRandomStringsTest()
        {
            var actual = RandomValueEx.GetRandomStrings( 100 );
            Assert.AreEqual( 100, actual.Count );
            actual.ForEach( x => Assert.IsTrue( x.Length > 0 ) );
        }

        [Test]
        public void GetRandomStringTest()
        {
            var actual = RandomValueEx.GetRandomString();
            Assert.IsTrue( actual.Length > 0 );
        }
    }
}