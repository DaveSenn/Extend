#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void SplitTestCase()
        {
            var actual = "1,2,3".Split( "," );
            Assert.AreEqual( 3, actual.Length );
            Assert.AreEqual( "1", actual[0] );
            Assert.AreEqual( "2", actual[1] );
            Assert.AreEqual( "3", actual[2] );
        }

        [Test]
        public void SplitTestCase1()
        {
            var actual = "1,2,,3.4".Split( StringSplitOptions.RemoveEmptyEntries, ",", "." );
            Assert.AreEqual( 4, actual.Length );
            Assert.AreEqual( "1", actual[0] );
            Assert.AreEqual( "2", actual[1] );
            Assert.AreEqual( "3", actual[2] );
            Assert.AreEqual( "4", actual[3] );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SplitTestCase1NullCheck()
        {
            var actual = StringEx.Split( null, StringSplitOptions.RemoveEmptyEntries, "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SplitTestCase1NullCheck1()
        {
            var actual = "".Split( StringSplitOptions.RemoveEmptyEntries, null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SplitTestCaseNullCheck()
        {
            var actual = StringEx.Split( null, "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SplitTestCaseNullCheck1()
        {
            var actual = StringEx.Split( "", null );
        }
    }
}