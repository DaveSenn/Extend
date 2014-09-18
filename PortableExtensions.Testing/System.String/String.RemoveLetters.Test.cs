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
        public void RemoveLettersTestCase()
        {
            var actual = "a1-b2.c3".RemoveLetters();
            Assert.AreEqual( "1-2.3", actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RemoveLettersTestCaseNullCheck()
        {
            StringEx.RemoveLetters( null );
        }
    }
}