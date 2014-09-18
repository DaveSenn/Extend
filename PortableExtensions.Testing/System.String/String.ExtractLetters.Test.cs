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
        public void ExtractLettersTestCase()
        {
            var actual = "1a2b3c4".ExtractLetters();
            Assert.AreEqual( "abc", actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractLettersTestCaseNullCheck()
        {
            var actual = StringEx.ExtractLetters( null );
        }
    }
}