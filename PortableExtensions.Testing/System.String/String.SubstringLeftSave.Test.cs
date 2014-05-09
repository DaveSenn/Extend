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
        public void SubstringLeftSaveTestCase()
        {
            var actual = "testabc".SubstringLeftSave( 4 );
            Assert.AreEqual( "test", actual );

            actual = "testabc".SubstringLeftSave( 400 );
            Assert.AreEqual( "testabc", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SubstringLeftSaveTestCaseNullCheck()
        {
            var actual = StringEx.SubstringLeftSave( null, 5 );
        }
    }
}