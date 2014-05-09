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
        public void GetBeforeTestCase()
        {
            var actual = "test test1".GetBefore( "test1" );
            Assert.AreEqual( "test ", actual );

            actual = "test test test".GetBefore( "test", 8 );
            Assert.AreEqual( "t ", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBeforeTestCaseNullCheck()
        {
            var actual = StringEx.GetBefore( null, "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBeforeTestCaseNullCheck1()
        {
            var actual = "".GetBefore( null );
        }

        [TestCase]
        public void GetBeforeTestCase1()
        {
            var actual = "test test1".GetBefore( "test1", 0, 10 );
            Assert.AreEqual( "test ", actual );

            actual = "test test test".GetBefore( "test", 8, 6 );
            Assert.AreEqual( "t ", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBeforeTestCase1NullCheck()
        {
            var actual = StringEx.GetBefore( null, "", 1, 1 );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetBeforeTestCase1NullCheck1()
        {
            var actual = "".GetBefore( null, 1, 1 );
        }
    }
}