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
        public void ExtractNumbersTestCase()
        {
            var actual = "1a2b3c4".ExtractNumbers();
            Assert.AreEqual( "1234", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractNumbersTestCaseNullCheck()
        {
            var actual = StringEx.ExtractNumbers( null );
        }
    }
}