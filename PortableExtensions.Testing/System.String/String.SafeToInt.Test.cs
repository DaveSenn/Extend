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
        public void SafeToIntTestCase()
        {
            var actual = "1".SafeToInt();
            Assert.AreEqual( 1, actual );

            actual = "1asd".SafeToInt();
            Assert.AreEqual( null, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SafeToIntTestCaseNullCheck()
        {
            var actual = StringEx.SafeToInt( null );
        }
    }
}