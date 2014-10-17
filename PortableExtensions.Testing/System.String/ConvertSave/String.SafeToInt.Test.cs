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
        public void SafeToIntTestCase ()
        {
            var actual = "1".SafeToInt();
            Assert.AreEqual( 1, actual );

            actual = "1asd".SafeToInt();
            Assert.AreEqual( null, actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SafeToIntTestCaseNullCheck ()
        {
            var actual = StringEx.SafeToInt( null );
        }
    }
}