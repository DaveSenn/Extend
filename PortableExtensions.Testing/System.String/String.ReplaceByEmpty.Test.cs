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
        public void ReplaceByEmptyTestCase()
        {
            var actual = "abcd".ReplaceByEmpty( "a", "c" );
            Assert.AreEqual( "bd", actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ReplaceByEmptyTestCaseNullCheck()
        {
            var actual = StringEx.ReplaceByEmpty( null, "a", "c" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ReplaceByEmptyTestCaseNullCheck1()
        {
            var actual = "".ReplaceByEmpty( null );
        }
    }
}