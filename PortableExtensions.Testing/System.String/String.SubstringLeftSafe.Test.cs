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
        public void SubstringLeftSafeTestCase()
        {
            var actual = "testabc".SubstringLeftSafe( 4 );
            Assert.AreEqual( "test", actual );

            actual = "testabc".SubstringLeftSafe( 400 );
            Assert.AreEqual( "testabc", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SubstringLeftSafeTestCaseNullCheck()
        {
            var actual = StringEx.SubstringLeftSafe( null, 5 );
        }
    }
}