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
        public void RemoveLettersTestCase()
        {
            var actual = "a1-b2.c3".RemoveLetters();
            Assert.AreEqual( "1-2.3", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RemoveLettersTestCaseNullCheck()
        {
            StringEx.RemoveLetters( null );
        }
    }
}