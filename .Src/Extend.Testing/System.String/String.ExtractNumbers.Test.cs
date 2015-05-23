#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ExtractNumbersTestCase()
        {
            var actual = "1a2b3c4".ExtractNumbers();
            Assert.AreEqual( "1234", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExtractNumbersTestCaseNullCheck()
        {
            StringEx.ExtractNumbers( null );
        }
    }
}