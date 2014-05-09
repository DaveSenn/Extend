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
        public void SubstringRightTestCase()
        {
            var actual = "testabc".SubstringRight( 3 );
            Assert.AreEqual( "abc", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SubstringRightTestCaseNullCheck()
        {
            var actual = StringEx.SubstringRight( null, 5 );
        }
    }
}