#region Usings

using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void IsMatchTestCase()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsMatch( emaiLpattern );
            Assert.IsTrue( actual );

            actual = invalidEmail.IsMatch( emaiLpattern );
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsMatchTestCase1()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsMatch( emaiLpattern, RegexOptions.Compiled );
            Assert.IsTrue( actual );

            actual = invalidEmail.IsMatch( emaiLpattern, RegexOptions.None );
            Assert.IsFalse( actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void IsMatchTestCase1NullCheck()
        {
            StringEx.IsMatch( null, "", RegexOptions.CultureInvariant );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void IsMatchTestCase1NullCheck1()
        {
            "".IsMatch( null, RegexOptions.Multiline );
        }

#if PORTABLE45
        [Test]
        public void IsMatchTestCase2()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsMatch( emaiLpattern, RegexOptions.Compiled, 10.ToSeconds() );
            Assert.IsTrue( actual );

            actual = invalidEmail.IsMatch( emaiLpattern, RegexOptions.None, 10.ToSeconds() );
            Assert.IsFalse( actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void IsMatchTestCase2NullCheck()
        {
            StringEx.IsMatch( null, "", RegexOptions.CultureInvariant, 10.ToSeconds() );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void IsMatchTestCase2NullCheck1()
        {
            "".IsMatch( null, RegexOptions.Multiline, 10.ToSeconds() );
        }
#endif

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void IsMatchTestCaseNullCheck()
        {
            StringEx.IsMatch( null, "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void IsMatchTestCaseNullCheck1()
        {
            "".IsMatch( null );
        }
    }
}