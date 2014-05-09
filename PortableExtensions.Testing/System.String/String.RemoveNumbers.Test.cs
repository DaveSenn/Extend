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
        public void RemoveNumbersTestCase()
        {
            var actual = "a1-b2.c3".RemoveNumbers();
            Assert.AreEqual( "a-b.c", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RemoveNumbersTestCaseNullCheck()
        {
            StringEx.RemoveNumbers( null );
        }
    }
}