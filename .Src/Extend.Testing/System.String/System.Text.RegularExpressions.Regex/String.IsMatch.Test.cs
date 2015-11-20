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
        public void IsMatchTestCase1NullCheck()
        {
            Action test = () => StringEx.IsMatch( null, "", RegexOptions.CultureInvariant );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsMatchTestCase1NullCheck1()
        {
            Action test = () => "".IsMatch( null, RegexOptions.Multiline );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsMatchTestCaseNullCheck()
        {
            Action test = () => StringEx.IsMatch( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsMatchTestCaseNullCheck1()
        {
            Action test = () => "".IsMatch( null );

            test.ShouldThrow<ArgumentNullException>();
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
        public void IsMatchTestCase2NullCheck()
        {
            Action test = () => StringEx.IsMatch( null, "", RegexOptions.CultureInvariant, 10.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsMatchTestCase2NullCheck1()
        {
            Action test = () => "".IsMatch( null, RegexOptions.Multiline, 10.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }
#endif
    }
}