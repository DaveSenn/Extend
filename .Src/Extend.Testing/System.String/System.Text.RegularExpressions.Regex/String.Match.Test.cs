#region Usings

using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void MatchTestCase()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Match( emaiLpattern );
            Assert.IsTrue( actual.Success );

            actual = invalidEmail.Match( emaiLpattern );
            Assert.IsFalse( actual.Success );
        }

        [Test]
        public void MatchTestCase1()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Match( emaiLpattern, RegexOptions.Compiled );
            Assert.IsTrue( actual.Success );

            actual = invalidEmail.Match( emaiLpattern, RegexOptions.Compiled );
            Assert.IsFalse( actual.Success );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void MatchTestCase1NullCheck()
        {
            StringEx.Match( null, "", RegexOptions.Compiled );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void MatchTestCase1NullCheck1()
        {
            "".Match( null, RegexOptions.Compiled );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void MatchTestCaseNullCheck()
        {
            StringEx.Match( null, "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void MatchTestCaseNullCheck1()
        {
            "".Match( null );
        }

#if PORTABLE45
        [Test]
        public void MatchTestCase2()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Match( emaiLpattern, RegexOptions.Compiled, 100.ToSeconds() );
            Assert.IsTrue( actual.Success );

            actual = invalidEmail.Match( emaiLpattern, RegexOptions.Compiled, 100.ToSeconds() );
            Assert.IsFalse( actual.Success );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void MatchTestCase2NullCheck()
        {
            StringEx.Match( null, "", RegexOptions.Compiled, 100.ToSeconds() );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void MatchTestCase2NullCheck1()
        {
            "".Match( null, RegexOptions.Compiled, 100.ToSeconds() );
        }

        [Test]
        [ExpectedException( typeof (RegexMatchTimeoutException) )]
        public void MatchTimeoutTestCase()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var text = RandomValueEx.GetRandomStrings( 50000 )
                                    .StringJoin();

            var actual = text.Match( emaiLpattern, RegexOptions.Compiled, 3.ToMilliseconds() );
        }
#endif
    }
}