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
        public void ReplaceByEmptyTestCase()
        {
            var actual = "abcd".ReplaceByEmpty( "a", "c" );
            Assert.AreEqual( "bd", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ReplaceByEmptyTestCaseNullCheck()
        {
            var actual = StringEx.ReplaceByEmpty( null, "a", "c" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ReplaceByEmptyTestCaseNullCheck1()
        {
            var actual = "".ReplaceByEmpty( null );
        }
    }
}