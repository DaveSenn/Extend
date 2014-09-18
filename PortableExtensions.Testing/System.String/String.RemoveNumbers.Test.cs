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
        public void RemoveNumbersTestCase()
        {
            var actual = "a1-b2.c3".RemoveNumbers();
            Assert.AreEqual( "a-b.c", actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RemoveNumbersTestCaseNullCheck()
        {
            StringEx.RemoveNumbers( null );
        }
    }
}