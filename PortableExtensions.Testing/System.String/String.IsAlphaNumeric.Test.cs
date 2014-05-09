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
        public void IsAlphaNumericTestCase()
        {
            var actual = "test".IsAlphaNumeric();
            Assert.IsTrue( actual );

            actual = "1test".IsAlphaNumeric();
            Assert.IsTrue( actual );

            actual = "1te-st".IsAlphaNumeric();
            Assert.IsFalse( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IsAlphaNumericTestCaseNullCheck()
        {
            StringEx.IsAlphaNumeric( null );
        }
    }
}