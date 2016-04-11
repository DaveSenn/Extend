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
        public void MatchTest()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Match( emaiLpattern );
            Assert.IsTrue( actual.Success );

            actual = invalidEmail.Match( emaiLpattern );
            Assert.IsFalse( actual.Success );
        }

        [Test]
        public void MatchTest1()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Match( emaiLpattern, RegexOptions.Compiled );
            Assert.IsTrue( actual.Success );

            actual = invalidEmail.Match( emaiLpattern, RegexOptions.Compiled );
            Assert.IsFalse( actual.Success );
        }

        [Test]
        public void MatchTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Match( null, "", RegexOptions.Compiled );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MatchTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Match( null, RegexOptions.Compiled );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MatchTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Match( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MatchTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Match( null );

            test.ShouldThrow<ArgumentNullException>();
        }

#if PORTABLE45
        [Test]
        public void MatchTest2()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "firstname.lastname@myDomain.com";
            const String invalidEmail = "firstname.lastname-myDomain.com";

            var actual = validEmail.Match( emaiLpattern, RegexOptions.Compiled, 100.ToSeconds() );
            Assert.IsTrue( actual.Success );

            actual = invalidEmail.Match( emaiLpattern, RegexOptions.Compiled, 100.ToSeconds() );
            Assert.IsFalse( actual.Success );
        }

        [Test]
        public void MatchTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Match( null, "", RegexOptions.Compiled, 100.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MatchTest2NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Match( null, RegexOptions.Compiled, 100.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MatchTimeoutTest()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var text = RandomValueEx.GetRandomStrings( 50000 )
                                    .StringJoin();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => text.Match( emaiLpattern, RegexOptions.Compiled, 3.ToMilliseconds() );

            test.ShouldThrow<RegexMatchTimeoutException>();
        }
#endif
    }
}