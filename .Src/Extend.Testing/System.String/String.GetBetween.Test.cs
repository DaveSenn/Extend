#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        public void GetBetweenArgumentOutOfRangeTestCase()
        {
            "121test2".GetBetween( "1", "2", 20 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        public void GetBetweenArgumentOutOfRangeTestCase1()
        {
            "1test2".GetBetween( "1", "2", 20, 2 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        public void GetBetweenArgumentOutOfRangeTestCase2()
        {
            "121test2".GetBetween( "1", "2", 2, 60 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        public void GetBetweenArgumentOutOfRangeTestCase3()
        {
            "121test2".GetBetween( "1", "2", -2, 60 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        public void GetBetweenArgumentOutOfRangeTestCase4()
        {
            "121test2".GetBetween( "1", "2", 2, -60 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        public void GetBetweenCharArgumentOutOfRangeTestCase()
        {
            "121test2".GetBetween( '1', '2', 20 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        public void GetBetweenCharArgumentOutOfRangeTestCase1()
        {
            "1test2".GetBetween( '1', '2', 20, 2 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        public void GetBetweenCharArgumentOutOfRangeTestCase2()
        {
            "121test2".GetBetween( '1', '2', 2, 60 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        public void GetBetweenCharArgumentOutOfRangeTestCase3()
        {
            "121test2".GetBetween( '1', '2', -2, 60 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        public void GetBetweenCharArgumentOutOfRangeTestCase4()
        {
            "121test2".GetBetween( '1', '2', 2, -60 );
        }

        [Test]
        public void GetBetweenCharTestCase()
        {
            var actual = "1test2".GetBetween( '1', '2' );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( '1', '2', 2 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        public void GetBetweenCharTestCase1()
        {
            var actual = "1test2".GetBetween( '1', '2', 0, 6 );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( '1', '2', 2, 6 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetBetweenCharTestCase1NullCheck()
        {
            var actual = StringEx.GetBetween( null, 't', 't' );
        }

        [Test]
        public void GetBetweenCharTestCase2()
        {
            var actual = "1test2".GetBetween( 'a', '2' );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBetweenCharTestCase3()
        {
            var actual = "1test2".GetBetween( 't', 'b' );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetBetweenCharTestCaseNullCheck()
        {
            var actual = StringEx.GetBetween( null, 't', 't' );
        }

        [Test]
        public void GetBetweenTestCase()
        {
            var actual = "1test2".GetBetween( "1", "2" );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( "1", "2", 2 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        public void GetBetweenTestCase1()
        {
            var actual = "1test2".GetBetween( "1", "2", 0, 6 );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( "1", "2", 2, 6 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetBetweenTestCase1NullCheck()
        {
            var actual = StringEx.GetBetween( null, "", "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetBetweenTestCase1NullCheck1()
        {
            var actual = "".GetBetween( null, "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetBetweenTestCase1NullCheck2()
        {
            var actual = "".GetBetween( "", null );
        }

        [Test]
        public void GetBetweenTestCase2()
        {
            var actual = "1test2".GetBetween( "1", "a" );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBetweenTestCase3()
        {
            var actual = "1test2".GetBetween( "a", "t" );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetBetweenTestCaseNullCheck()
        {
            var actual = StringEx.GetBetween( null, "", "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetBetweenTestCaseNullCheck1()
        {
            var actual = "".GetBetween( null, "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetBetweenTestCaseNullCheck2()
        {
            var actual = "".GetBetween( "", null );
        }
    }
}