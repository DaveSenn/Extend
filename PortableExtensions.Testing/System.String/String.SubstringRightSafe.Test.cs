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
        public void SubstringRightSafeTestCase ()
        {
            var actual = "testabc".SubstringRightSafe( 3 );
            Assert.AreEqual( "abc", actual );

            actual = "testabc".SubstringRightSafe( 300 );
            Assert.AreEqual( "testabc", actual );

            actual = "".SubstringRightSafe( 300 );
            Assert.AreEqual( "", actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SubstringRightSafeTestCaseNullCheck ()
        {
            var actual = StringEx.SubstringRight( null, 5 );
        }
    }
}