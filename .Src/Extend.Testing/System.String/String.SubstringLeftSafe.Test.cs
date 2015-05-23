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
        public void SubstringLeftSafeTestCase()
        {
            var actual = "testabc".SubstringLeftSafe( 4 );
            Assert.AreEqual( "test", actual );

            actual = "testabc".SubstringLeftSafe( 400 );
            Assert.AreEqual( "testabc", actual );

            actual = "".SubstringLeftSafe( 4 );
            Assert.AreEqual( "", actual );
        }

        [Test]
        public void SubstringLeftSafeTestCase1()
        {
            var actual = "123test123".SubstringLeftSafe( 3, 4 );
            Assert.AreEqual( "test", actual );

            actual = "testabc".SubstringLeftSafe( 0, 400 );
            Assert.AreEqual( "testabc", actual );

            actual = "123tes".SubstringLeftSafe( 3, 4 );
            Assert.AreEqual( "tes", actual );

            actual = "".SubstringLeftSafe( 0, 4 );
            Assert.AreEqual( "", actual );

            actual = "".SubstringLeftSafe( 2, 4 );
            Assert.AreEqual( "", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SubstringLeftSafeTestCase1NullCheck()
        {
            StringEx.SubstringLeftSafe( null, 1, 5 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SubstringLeftSafeTestCaseNullCheck()
        {
            StringEx.SubstringLeftSafe( null, 5 );
        }
    }
}