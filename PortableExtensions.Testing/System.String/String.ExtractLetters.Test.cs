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
        public void ExtractLettersTestCase()
        {
            var actual = "1a2b3c4".ExtractLetters();
            Assert.AreEqual( "abc", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractLettersTestCaseNullCheck()
        {
            var actual = StringEx.ExtractLetters( null );
        }
    }
}