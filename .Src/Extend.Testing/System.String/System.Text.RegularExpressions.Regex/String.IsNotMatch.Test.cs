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
        public void IsNotMatchTest()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsNotMatch( emaiLpattern );
            Assert.IsFalse( actual );

            actual = invalidEmail.IsNotMatch( emaiLpattern );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsNotMatchTest1()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsNotMatch( emaiLpattern, RegexOptions.Compiled );
            Assert.IsFalse( actual );

            actual = invalidEmail.IsNotMatch( emaiLpattern, RegexOptions.None );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsNotMatchTest1NullCheck()
        {
            Action test = () => StringEx.IsNotMatch( null, "", RegexOptions.CultureInvariant );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsNotMatchTest1NullCheck1()
        {
            Action test = () => "".IsNotMatch( null, RegexOptions.Multiline );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsNotMatchTestNullCheck()
        {
            Action test = () => StringEx.IsNotMatch( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsNotMatchTestNullCheck1()
        {
            Action test = () => "".IsNotMatch( null );

            test.ShouldThrow<ArgumentNullException>();
        }

#if PORTABLE45
        [Test]
        public void IsNotMatchTest2()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = "dave.senn@myDomain.com";
            var invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsNotMatch( emaiLpattern, RegexOptions.Compiled, 10.ToSeconds() );
            Assert.IsFalse( actual );

            actual = invalidEmail.IsNotMatch( emaiLpattern, RegexOptions.None, 10.ToSeconds() );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsNotMatchTest2NullCheck()
        {
            Action test = () => StringEx.IsNotMatch( null, "", RegexOptions.CultureInvariant, 10.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsNotMatchTest2NullCheck1()
        {
            Action test = () => "".IsNotMatch( null, RegexOptions.Multiline, 10.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsNotMatchTest2TimeoutCheck()
        {
            var emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = RandomValueEx.GetRandomStrings( 10000 )
                                          .StringJoin( Environment.NewLine );

            Action test = () => validEmail.IsNotMatch( emaiLpattern, RegexOptions.Multiline, 3.ToMilliseconds() );

            test.ShouldThrow<RegexMatchTimeoutException>();
        }
#endif
    }
}