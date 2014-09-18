#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DecimalExTest
    {
        [Test]
        public void SumTestCase()
        {
            var actual = new Decimal( 10 ).Sum( new Decimal( 20 ),
                                                new Decimal( 30 ),
                                                new Decimal( 40 ),
                                                new Decimal( 50 ) );
            Assert.AreEqual( new Decimal( 150 ), actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCaseNullCheck()
        {
            Decimal[] values = null;
            var actual = new Decimal( 10 ).Sum( values );
        }

        [Test]
        public void SumTestCase1()
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
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase1NullCheck()
        {
            Decimal?[] values = null;
            var actual = ( new Decimal( 10 ) as Decimal? ).Sum( values );
        }

        [Test]
        public void SumTestCase2()
        {
            var actual = "test".Sum( x => new Decimal( x.Length ), "a", "b", "c", "d" );
            Assert.AreEqual( new Decimal( 8 ), actual );

            actual = "".Sum( x => new Decimal( x.Length ), "a", "b", "c", "d" );
            Assert.AreEqual( new Decimal( 4 ), actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase2NullCheck2()
        {
            Func<String, Decimal> func = null;
            var actual = "Test".Sum( func, "test", "test2" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase2NullCheck()
        {
            String[] values = null;
            var actual = "Test".Sum( x => new Decimal( x.Length ), values );
        }

        [Test]
        public void SumTestCase3()
        {
            var actual = "test".Sum( x => new Decimal( x.Length ) > 1m ? (Decimal?) x.Length : null, "a", "b", "c", "d" );
            Assert.AreEqual( 4, actual );

            actual = "test".Sum( x => new Decimal( x.Length ) > 1m ? (Decimal?) x.Length : null, "aaaa", "b", "c", "d" );
            Assert.AreEqual( 8, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase3NullCheck2()
        {
            Func<String, Decimal?> func = null;
            var actual = "Test".Sum( func, "test", "test2" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase3NullCheck()
        {
            String[] values = null;
            var actual = "Test".Sum( x => (Decimal?) x.Length, values );
        }
    }
}