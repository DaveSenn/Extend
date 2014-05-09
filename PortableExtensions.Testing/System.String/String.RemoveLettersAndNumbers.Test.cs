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
        public void RemoveLettersAndNumbersTestCase()
        {
            var actual = "a1-b2.c3".RemoveLettersAndNumbers();
            Assert.AreEqual( "-.", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RemoveLettersAndNumbersTestCaseNullCheck()
        {
            StringEx.RemoveLettersAndNumbers( null );
        }
    }
}