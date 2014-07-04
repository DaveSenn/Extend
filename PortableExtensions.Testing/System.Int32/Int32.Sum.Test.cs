#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [TestCase]
        public void SumTestCase()
        {
            var actual = 10.Sum( 20, 30, 40, 50 );
            Assert.AreEqual( 150, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCaseNullCheck()
        {
            Int32[] values = null;
            var actual = 10.Sum( values );
        }

        [TestCase]
        public void SumTestCase1()
        {
            var actual = ( 10 as Int32? ).Sum( 20, null, 40, null );
            Assert.AreEqual( 70, actual );

            actual = ( null as Int32? ).Sum( new Int32?[]
            {
                null,
                null
            } );
            Assert.AreEqual( 0, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase1NullCheck()
        {
            Int32?[] values = null;
            var actual = ( 10 as Int32? ).Sum( values );
        }

        [TestCase]
        public void SumTestCase2()
        {
            var actual = "test".Sum( x => x.Length, "a", "b", "c", "d" );
            Assert.AreEqual( 8, actual );

            actual = "".Sum( x => x.Length, "a", "b", "c", "d" );
            Assert.AreEqual( 4, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase2NullCheck2()
        {
            Func<String, Int32> func = null;
            var actual = "Test".Sum( func, "test", "test2" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase2NullCheck()
        {
            String[] values = null;
            var actual = "Test".Sum( x => x.Length, values );
        }

        [TestCase]
        public void SumTestCase3()
        {
            var actual = "test".Sum( x => x.Length > 1 ? (Int32?) x.Length : null, "a", "b", "c", "d" );
            Assert.AreEqual( 4, actual );

            actual = "test".Sum( x => x.Length > 1 ? (Int32?) x.Length : null, "aaaa", "b", "c", "d" );
            Assert.AreEqual( 8, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase3NullCheck2()
        {
            Func<String, Int32?> func = null;
            var actual = "Test".Sum( func, "test", "test2" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase3NullCheck()
        {
            String[] values = null;
            var actual = "Test".Sum( x => (Int32?) x.Length, values );
        }
    }
}