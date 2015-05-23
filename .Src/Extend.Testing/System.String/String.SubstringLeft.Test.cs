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
        public void SubstringLeftTestCase()
        {
            var actual = "testabc".SubstringLeft( 4 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SubstringLeftTestCaseNullCheck()
        {
            var actual = StringEx.SubstringLeft( null, 1 );
        }
    }
}