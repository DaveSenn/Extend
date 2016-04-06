#region Usings

using System;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void MatchesTest()
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
        public void MatchesTest1()
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
        public void MatchesTest1NullCheck()
        {
            Action test = () => StringEx.Matches( null, "", RegexOptions.Compiled );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MatchesTest1NullCheck1()
        {
            Action test = () => "".Matches( null, RegexOptions.Compiled );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MatchesTestNullCheck()
        {
            Action test = () => StringEx.Matches( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MatchesTestNullCheck1()
        {
            Action test = () => "".Matches( null );

            test.ShouldThrow<ArgumentNullException>();
        }

#if PORTABLE45
        [Test]
        public void MatchesTest2()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Matches( emaiLpattern, RegexOptions.Compiled, 100.ToSeconds() );
            Assert.AreEqual( 1, actual.Count );

            actual = invalidEmail.Matches( emaiLpattern, RegexOptions.Compiled, 100.ToSeconds() );
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void MatchesTest2NullCheck()
        {
            Action test = () => StringEx.Matches( null, "", RegexOptions.Compiled, 100.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MatchesTest2NullCheck1()
        {
            Action test = () => "".Matches( null, RegexOptions.Compiled, 100.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }
#endif
    }
}