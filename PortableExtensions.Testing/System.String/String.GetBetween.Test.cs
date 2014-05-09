#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void GetBetweenTestCase()
        {
            var actual = "1test2".GetBetween( "1", "2" );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( "1", "2", 2 );
            Assert.AreEqual( "test", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBetweenTestCaseNullCheck()
        {
            var actual = StringEx.GetBetween( null, "", "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBetweenTestCaseNullCheck1()
        {
            var actual = "".GetBetween( null, "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBetweenTestCaseNullCheck2()
        {
            var actual = "".GetBetween( "", null );
        }

        [TestCase]
        public void GetBetweenTestCase1()
        {
            var actual = "1test2".GetBetween( "1", "2", 0, 6 );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( "1", "2", 2, 6 );
            Assert.AreEqual( "test", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBetweenTestCase1NullCheck()
        {
            var actual = StringEx.GetBetween( null, "", "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBetweenTestCase1NullCheck1()
        {
            var actual = "".GetBetween( null, "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBetweenTestCase1NullCheck2()
        {
            var actual = "".GetBetween( "", null );
        }
    }
}