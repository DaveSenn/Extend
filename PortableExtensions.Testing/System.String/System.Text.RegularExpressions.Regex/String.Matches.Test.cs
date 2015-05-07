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
        public void MatchesTestCase()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Matches( emaiLpattern );
            Assert.AreEqual( 1, actual.Count );

            actual = invalidEmail.Matches( emaiLpattern );
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void MatchesTestCase1()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Matches( emaiLpattern, RegexOptions.Compiled );
            Assert.AreEqual( 1, actual.Count );

            actual = invalidEmail.Matches( emaiLpattern, RegexOptions.Compiled );
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void MatchesTestCase1NullCheck()
        {
            StringEx.Matches( null, "", RegexOptions.Compiled );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void MatchesTestCase1NullCheck1()
        {
            "".Matches( null, RegexOptions.Compiled );
        }

        [Test]
        public void MatchesTestCase2()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Matches( emaiLpattern, RegexOptions.Compiled, 100.ToSeconds() );
            Assert.AreEqual( 1, actual.Count );

            actual = invalidEmail.Matches( emaiLpattern, RegexOptions.Compiled, 100.ToSeconds() );
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void MatchesTestCase2NullCheck()
        {
            StringEx.Matches( null, "", RegexOptions.Compiled, 100.ToSeconds() );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void MatchesTestCase2NullCheck1()
        {
            "".Matches( null, RegexOptions.Compiled, 100.ToSeconds() );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void MatchesTestCaseNullCheck()
        {
            StringEx.Matches( null, "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void MatchesTestCaseNullCheck1()
        {
            "".Matches( null );
        }
    }
}