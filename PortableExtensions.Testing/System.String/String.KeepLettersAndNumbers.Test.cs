#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void KeepLettersAndNumbersTestCase()
        {
            var actual = "a1b2c3".KeepLettersAndNumbers();
            Assert.AreEqual( "a1b2c3", actual );

            actual = "a1.b2-c3".KeepLettersAndNumbers();
            Assert.AreEqual( "a1b2c3", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void KeepLettersAndNumbersTestCaseNullCheck()
        {
            StringEx.KeepLettersAndNumbers( null );
        }
    }
}