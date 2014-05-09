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
        public void SubstringLeftTestCase()
        {
            var actual = "testabc".SubstringLeft( 4 );
            Assert.AreEqual( "test", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SubstringLeftTestCaseNullCheck()
        {
            var actual = StringEx.SubstringLeft( null, 1 );
        }
    }
}