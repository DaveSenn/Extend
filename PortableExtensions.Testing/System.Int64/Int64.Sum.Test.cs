#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [Test]
        public void SumTestCase()
        {
            var actual = ( (Int64) 10 ).Sum( 20, 30, 40, 50 );
            Assert.AreEqual( 150, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCaseNullCheck()
        {
            Int64[] values = null;
            var actual = ( (Int64) 10 ).Sum( values );
        }

        [Test]
        public void SumTestCase1()
        {
            var actual = ( (Int64?) 10 ).Sum( 20, null, 40, null );
            Assert.AreEqual( 70, actual );

            actual = ( null as Int64? ).Sum( new Int64?[]
            {
                null,
                null
            } );
            Assert.AreEqual( 0, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase1NullCheck()
        {
            Int64?[] values = null;
            var actual = ( (Int64?) 10 ).Sum( values );
        }

        [Test]
        public void SumTestCase2()
        {
            var actual = "test".Sum( x => (Int64) x.Length, "a", "b", "c", "d" );
            Assert.AreEqual( 8, actual );

            actual = "".Sum( x => (Int64) x.Length, "a", "b", "c", "d" );
            Assert.AreEqual( 4, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase2NullCheck2()
        {
            Func<String, Int64> func = null;
            var actual = "Test".Sum( func, "test", "test2" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase2NullCheck()
        {
            String[] values = null;
            var actual = "Test".Sum( x => (Int64) x.Length, values );
        }

        [Test]
        public void SumTestCase3()
        {
            var actual = "test".Sum( x => x.Length > 1 ? (Int64?) x.Length : null, "a", "b", "c", "d" );
            Assert.AreEqual( 4, actual );

            actual = "test".Sum( x => x.Length > 1 ? (Int64?) x.Length : null, "aaaa", "b", "c", "d" );
            Assert.AreEqual( 8, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase3NullCheck2()
        {
            Func<String, Int64?> func = null;
            var actual = "Test".Sum( func, "test", "test2" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase3NullCheck()
        {
            String[] values = null;
            var actual = "Test".Sum( x => (Int64?) x.Length, values );
        }
    }
}