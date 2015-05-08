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
        public void SubstringRightTestCase()
        {
            var actual = "testabc".SubstringRight( 3 );
            Assert.AreEqual( "abc", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SubstringRightTestCaseNullCheck()
        {
            var actual = StringEx.SubstringRight( null, 5 );
        }
    }
}