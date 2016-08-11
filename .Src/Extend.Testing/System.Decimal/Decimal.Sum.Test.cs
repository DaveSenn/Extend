#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class DecimalExTest
    {
        [Test]
        public void SumTest()
        {
            var actual = new Decimal( 10 ).Sum( new Decimal( 20 ),
                                                new Decimal( 30 ),
                                                new Decimal( 40 ),
                                                new Decimal( 50 ) );
            Assert.AreEqual( new Decimal( 150 ), actual );
        }

        [Test]
        public void SumTest1()
        {
            var actual = ( new Decimal( 10 ) as Decimal? ).Sum( new Decimal( 20 ), null, new Decimal( 40 ), null );
            Assert.AreEqual( 70, actual );

            actual = ( null as Decimal? ).Sum( new Decimal?[]
            {
                null,
                null
            } );
            Assert.AreEqual( new Decimal( 0 ), actual );
        }

        [Test]
        public void SumTest1NullCheck()
        {
            Decimal?[] values = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ( new Decimal( 10 ) as Decimal? ).Sum( values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTest2()
        {
            var actual = "test".Sum( x => new Decimal( x.Length ), "a", "b", "c", "d" );
            Assert.AreEqual( new Decimal( 8 ), actual );

            actual = "".Sum( x => new Decimal( x.Length ), "a", "b", "c", "d" );
            Assert.AreEqual( new Decimal( 4 ), actual );
        }

        [Test]
        public void SumTest2NullCheck()
        {
            String[] values = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "Test".Sum( x => new Decimal( x.Length ), values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTest2NullCheck2()
        {
            Func<String, Decimal> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "Test".Sum( func, "test", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTest3()
        {
            var actual = "test".Sum( x => new Decimal( x.Length ) > 1m ? (Decimal?) x.Length : null, "a", "b", "c", "d" );
            Assert.AreEqual( 4, actual );

            actual = "test".Sum( x => new Decimal( x.Length ) > 1m ? (Decimal?) x.Length : null, "aaaa", "b", "c", "d" );
            Assert.AreEqual( 8, actual );
        }

        [Test]
        public void SumTest3NullCheck()
        {
            String[] values = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "Test".Sum( x => (Decimal?) x.Length, values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTest3NullCheck2()
        {
            Func<String, Decimal?> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "Test".Sum( func, "test", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTestNullCheck()
        {
            Decimal[] values = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new Decimal( 10 ).Sum( values );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}