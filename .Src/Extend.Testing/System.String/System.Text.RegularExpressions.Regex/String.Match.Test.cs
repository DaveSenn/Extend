#region Usings

using System;
using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void MatchTest()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Match( emaiLpattern );
            Assert.True( actual.Success );

            actual = invalidEmail.Match( emaiLpattern );
            Assert.False( actual.Success );
        }

        [Fact]
        public void MatchTest1()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Match( emaiLpattern, RegexOptions.Compiled );
            Assert.True( actual.Success );

            actual = invalidEmail.Match( emaiLpattern, RegexOptions.Compiled );
            Assert.False( actual.Success );
        }

        [Fact]
        public void MatchTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Match( null, "", RegexOptions.Compiled );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MatchTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Match( null, RegexOptions.Compiled );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MatchTest2()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "firstname.lastname@myDomain.com";
            const String invalidEmail = "firstname.lastname-myDomain.com";

            var actual = validEmail.Match( emaiLpattern, RegexOptions.Compiled, 100.ToSeconds() );
            Assert.True( actual.Success );

            actual = invalidEmail.Match( emaiLpattern, RegexOptions.Compiled, 100.ToSeconds() );
            Assert.False( actual.Success );
        }

        [Fact]
        public void MatchTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Match( null, "", RegexOptions.Compiled, 100.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MatchTest2NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Match( null, RegexOptions.Compiled, 100.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MatchTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Match( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MatchTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Match( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MatchTimeoutTest()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var text = RandomValueEx.GetRandomStrings( 50000 )
                                    .StringJoin();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => text.Match( emaiLpattern, RegexOptions.Compiled, 3.ToMilliseconds() );

            test.ShouldThrow<RegexMatchTimeoutException>();
        }
    }
}