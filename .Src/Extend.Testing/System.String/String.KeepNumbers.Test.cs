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
        public void KeepNumbersTestCase()
        {
            var actual = "a1b2c3".KeepNumbers();
            Assert.AreEqual( "123", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void KeepNumbersTEstCaseNullCheck()
        {
            StringEx.KeepNumbers( null );
        }
    }
}