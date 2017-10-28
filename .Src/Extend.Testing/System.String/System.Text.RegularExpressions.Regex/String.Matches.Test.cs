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
        public void MatchesTest()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Matches( emaiLpattern );
            Assert.Single( actual );

            actual = invalidEmail.Matches( emaiLpattern );
            Assert.Empty( actual );
        }

        [Fact]
        public void MatchesTest1()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Matches( emaiLpattern, RegexOptions.Compiled );
            Assert.Single( actual );

            actual = invalidEmail.Matches( emaiLpattern, RegexOptions.Compiled );
            Assert.Empty( actual );
        }

        [Fact]
        public void MatchesTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Matches( null, "", RegexOptions.Compiled );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MatchesTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Matches( null, RegexOptions.Compiled );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MatchesTest2()
        {
            const String emaiLpattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            const String validEmail = "dave.senn@myDomain.com";
            const String invalidEmail = "dave.senn-myDomain.com";

            var actual = validEmail.Matches( emaiLpattern, RegexOptions.Compiled, 100.ToSeconds() );
            Assert.Single( actual );

            actual = invalidEmail.Matches( emaiLpattern, RegexOptions.Compiled, 100.ToSeconds() );
            Assert.Empty( actual );
        }

        [Fact]
        public void MatchesTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Matches( null, "", RegexOptions.Compiled, 100.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MatchesTest2NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Matches( null, RegexOptions.Compiled, 100.ToSeconds() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MatchesTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Matches( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MatchesTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Matches( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}

/*
 public static MatchCollection Matches( [NotNull] this String input, [NotNull] String pattern, RegexOptions options, TimeSpan timeOut )
        {
            input.ThrowIfNull( nameof(input) );
            pattern.ThrowIfNull( nameof(pattern) );
            timeOut.ThrowIfNull( nameof(timeOut) );

            return Regex.Matches( input, pattern, options, timeOut );
        }
     */