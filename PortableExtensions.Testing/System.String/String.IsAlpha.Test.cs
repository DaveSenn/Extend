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
        public void IsAlphaTestCase()
        {
            var actual = "test".IsAlpha();
            Assert.IsTrue( actual );

            actual = "1test".IsAlpha();
            Assert.IsFalse( actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IsAlphaTestCaseNullCheck()
        {
            StringEx.IsAlpha( null );
        }
    }
}