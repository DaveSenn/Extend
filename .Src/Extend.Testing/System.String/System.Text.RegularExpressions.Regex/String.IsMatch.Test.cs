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
        public void IsMatchTest()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsMatch( emaiLpattern );
            Assert.True( actual );

            actual = invalidEmail.IsMatch( emaiLpattern );
            Assert.False( actual );
        }

        [Fact]
        public void IsMatchTest1()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsMatch( emaiLpattern, RegexOptions.Compiled );
            Assert.True( actual );

            actual = invalidEmail.IsMatch( emaiLpattern, RegexOptions.None );
            Assert.False( actual );
        }

        [Fact]
        public void IsMatchTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.IsMatch( null, "", RegexOptions.CultureInvariant );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsMatchTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".IsMatch( null, RegexOptions.Multiline );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsMatchTest2()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.IsMatch( emaiLpattern, RegexOptions.Compiled, 10.ToSeconds() );
            Assert.True( actual );

            actual = invalidEmail.IsMatch( emaiLpattern, RegexOptions.None, 10.ToSeconds() );
            Assert.False( actual );
        }

        [Fact]
        public void IsMatchTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.IsMatch( null, "", RegexOptions.CultureInvariant, 10.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsMatchTest2NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".IsMatch( null, RegexOptions.Multiline, 10.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsMatchTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.IsMatch( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsMatchTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".IsMatch( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}