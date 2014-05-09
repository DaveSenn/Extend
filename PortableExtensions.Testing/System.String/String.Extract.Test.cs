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
        public void ExtractTestCase()
        {
            var actual = "abcabc".Extract( x => x == 'a' );
            Assert.AreEqual( "aa", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractTestCaseNullCheck()
        {
            var actual = StringEx.Extract( null, y => false );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractTestCaseNullCheck1()
        {
            var actual = "".Extract( null );
        }
    }
}