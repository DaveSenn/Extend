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
        public void ExtractTestCase()
        {
            var actual = "abcabc".Extract( x => x == 'a' );
            Assert.AreEqual( "aa", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExtractTestCaseNullCheck()
        {
            var actual = StringEx.Extract( null, y => false );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExtractTestCaseNullCheck1()
        {
            var actual = "".Extract( null );
        }
    }
}