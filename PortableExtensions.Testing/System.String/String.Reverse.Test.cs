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
        public void ReverseTestCase1()
        {
            var actual = "a".Reverse();
            Assert.AreEqual("a", actual);
        }

        [Test]
        public void ReverseTestCase2()
        {
            var actual = "".Reverse();
            Assert.AreEqual("", actual);
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ReverseTestCaseNullCheck()
        {
            var actual = StringEx.Reverse( null );
        }
    }
}