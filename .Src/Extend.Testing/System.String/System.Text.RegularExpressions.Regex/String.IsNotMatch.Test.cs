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
        public void IsNotMatchTest()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsNotMatch( emaiLpattern );
            Assert.False( actual );

            actual = invalidEmail.IsNotMatch( emaiLpattern );
            Assert.True( actual );
        }

        [Fact]
        public void IsNotMatchTest1()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsNotMatch( emaiLpattern, RegexOptions.Compiled );
            Assert.False( actual );

            actual = invalidEmail.IsNotMatch( emaiLpattern, RegexOptions.None );
            Assert.True( actual );
        }

        [Fact]
        public void IsNotMatchTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.IsNotMatch( null, "", RegexOptions.CultureInvariant );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsNotMatchTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".IsNotMatch( null, RegexOptions.Multiline );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsNotMatchTest2()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsNotMatch( emaiLpattern, RegexOptions.Compiled, 10.ToSeconds() );
            Assert.False( actual );

            actual = invalidEmail.IsNotMatch( emaiLpattern, RegexOptions.None, 10.ToSeconds() );
            Assert.True( actual );
        }

        [Fact]
        public void IsNotMatchTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.IsNotMatch( null, "", RegexOptions.CultureInvariant, 10.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsNotMatchTest2NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".IsNotMatch( null, RegexOptions.Multiline, 10.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsNotMatchTest2TimeoutCheck()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            var validEmail = RandomValueEx.GetRandomStrings( 10000 )
                                          .StringJoin( Environment.NewLine );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => validEmail.IsNotMatch( emaiLpattern, RegexOptions.Multiline, 3.ToMilliseconds() );

            test.ShouldThrow<RegexMatchTimeoutException>();
        }

        [Fact]
        public void IsNotMatchTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.IsNotMatch( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsNotMatchTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".IsNotMatch( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}