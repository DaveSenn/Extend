#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void GetBeforeTestCase()
        {
            var actual = "test test1".GetBefore( "test1" );
            Assert.AreEqual( "test ", actual );

            actual = "test test test".GetBefore( "test", 8 );
            Assert.AreEqual( "t ", actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void GetBeforeArgumentOutOfRangExceptionTestCase()
        {
            "test test".GetBefore( "test", 15 );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBeforeTestCaseNullCheck()
        {
            StringEx.GetBefore( null, "" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBeforeTestCaseNullCheck1()
        {
            "".GetBefore( null );
        }

        [Test]
        public void GetBeforeTestCase1()
        {
            var actual = "test test1".GetBefore( "test1", 0, 10 );
            Assert.AreEqual( "test ", actual );

            actual = "test test test".GetBefore( "test", 8, 6 );
            Assert.AreEqual( "t ", actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void GetBeforeArgumentOutOfRangeTestCase1()
        {
            "test test1".GetBefore( "test1", 20, 2 );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void GetBeforeArgumentOutOfRangeTestCase2()
        {
            "test test test".GetBefore( "test", 2, 20 );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBeforeTestCase1NullCheck()
        {
            StringEx.GetBefore( null, "", 1, 1 );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBeforeTestCase1NullCheck1()
        {
            "".GetBefore( null, 1, 1 );
        }

        [Test]
        public void GetBeforeCharTestCase()
        {
            var actual = "test test1".GetBefore( 's' );
            Assert.AreEqual( "te", actual );

            actual = "test test test".GetBefore( 's', 5 );
            Assert.AreEqual( "te", actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void GetBeforeCharArgumentOutOfRangExceptionTestCase()
        {
            "test test".GetBefore( 't', 15 );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBeforeCharTestCaseNullCheck()
        {
            StringEx.GetBefore( null, 't' );
        }

        [Test]
        public void GetBeforeCharTestCase1()
        {
            var actual = "test test1".GetBefore( 'e', 0, 4 );
            Assert.AreEqual( "t", actual );

            actual = "test test test".GetBefore( 'e', 3, 5 );
            Assert.AreEqual( "t t", actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void GetBeforeCharArgumentOutOfRangeTestCase1()
        {
            "test test1".GetBefore( 't', 20, 2 );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void GetBeforeCharArgumentOutOfRangeTestCase2()
        {
            "test test test".GetBefore( 't', 2, 20 );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBeforeCharTestCase1NullCheck()
        {
            StringEx.GetBefore( null, 't', 1, 1 );
        }
    }
}