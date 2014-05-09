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
        public void GetAfterTestCase()
        {
            var actual = "test test1".GetAfter( "test" );
            Assert.AreEqual( " test1", actual );

            actual = "test test1".GetAfter( "test", 2 );
            Assert.AreEqual( "1", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetAfterTestCaseNullCheck()
        {
            var actual = StringEx.GetAfter( null, "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetAfterTestCaseNullCheck1()
        {
            var actual = "".GetAfter( null );
        }

        [TestCase]
        public void GetAfterTest1Case()
        {
            var actual = "test test1".GetAfter( "test", 0, 10 );
            Assert.AreEqual( " test1", actual );

            actual = "test test1".GetAfter( "test", 2, 8 );
            Assert.AreEqual( "1", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetAfterTestCase1NullCheck()
        {
            var actual = StringEx.GetAfter( null, "", 1, 1 );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetAfterTestCase1NullCheck1()
        {
            var actual = "".GetAfter( null, 1, 1 );
        }
    }
}