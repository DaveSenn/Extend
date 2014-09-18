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
        public void ReverseTestCase()
        {
            var actual = "abc".Reverse();
            Assert.AreEqual( "cba", actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ReverseTestCaseNullCheck()
        {
            var actual = StringEx.Reverse( null );
        }
    }
}