#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DoubleExTest
    {
        [TestCase]
        public void SumTestCase()
        {
            var actual = 10.1d.Sum( 20.1, 30.1, 40.1, 50.1 );
            Assert.AreEqual( 150.5, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCaseNullCheck()
        {
            Double[] values = null;
            var actual = 10.1.Sum( values );
        }

        [TestCase]
        public void SumTestCase1()
        {
            var actual = ( 10.5 as Double? ).Sum( 20.5, null, 40.5, null );
            Assert.AreEqual( 71.5, actual );

            actual = ( null as Double? ).Sum( new Double?[]
            {
                null,
                null
            } );
            Assert.AreEqual( 0d, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase1NullCheck()
        {
            Double?[] values = null;
            var actual = ( 10d as Double? ).Sum( values );
        }

        [TestCase]
        public void SumTestCase2()
        {
            var actual = "test".Sum( x => (Double) x.Length, "a", "b", "c", "d" );
            Assert.AreEqual( 8d, actual );

            actual = "".Sum( x => x.Length, "a", "b", "c", "d" );
            Assert.AreEqual( 4d, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase2NullCheck2()
        {
            Func<String, Double> func = null;
            var actual = "Test".Sum( func, "test", "test2" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase2NullCheck()
        {
            String[] values = null;
            var actual = "Test".Sum( x => (Double) x.Length, values );
        }

        [TestCase]
        public void SumTestCase3()
        {
            var actual = "test".Sum( x => x.Length > 1d ? (Double?) x.Length : null, "a", "b", "c", "d" );
            Assert.AreEqual( 4d, actual );

            actual = "test".Sum( x => x.Length > 1d ? (Double?) x.Length : null, "aaaa", "b", "c", "d" );
            Assert.AreEqual( 8d, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase3NullCheck2()
        {
            Func<String, Double?> func = null;
            var actual = "Test".Sum( func, "test", "test2" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SumTestCase3NullCheck()
        {
            String[] values = null;
            var actual = "Test".Sum( x => (Double?) x.Length, values );
        }
    }
}