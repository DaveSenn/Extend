#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void WildcardToRegexTest()
        {
            var actual = "*.txt".WildcardToRegex();

            actual.Should()
                  .Be( "^.*\\.txt$" );

            "test.txt".IsMatch( actual )
                      .Should()
                      .BeTrue();

            "C:\\Temp\\test.txt".IsMatch( actual )
                                .Should()
                                .BeTrue();

            "*.txt".IsMatch( actual )
                   .Should()
                   .BeTrue();

            "*txt".IsMatch( actual )
                  .Should()
                  .BeFalse();

            "txt".IsMatch( actual )
                 .Should()
                 .BeFalse();

            "test".IsMatch( actual )
                  .Should()
                  .BeFalse();
        }

        [Fact]
        public void WildcardToRegexTest1()
        {
            var actual = "txt".WildcardToRegex();

            actual.Should()
                  .Be( "^txt$" );

            "test.txt".IsMatch( actual )
                      .Should()
                      .BeFalse();

            "C:\\Temp\\test.txt".IsMatch( actual )
                                .Should()
                                .BeFalse();

            "*.txt".IsMatch( actual )
                   .Should()
                   .BeFalse();

            "*txt".IsMatch( actual )
                  .Should()
                  .BeFalse();

            "txt".IsMatch( actual )
                 .Should()
                 .BeTrue();

            "test".IsMatch( actual )
                  .Should()
                  .BeFalse();
        }

        [Fact]
        public void WildcardToRegexTest2()
        {
            var actual = "txt.*".WildcardToRegex();

            actual.Should()
                  .Be( "^txt\\..*$" );

            "txt.test".IsMatch( actual )
                      .Should()
                      .BeTrue();

            "txt.*".IsMatch( actual )
                   .Should()
                   .BeTrue();

            "C:\\Temp\\txt.test".IsMatch( actual )
                                .Should()
                                .BeFalse();

            "txt*".IsMatch( actual )
                  .Should()
                  .BeFalse();

            "txt".IsMatch( actual )
                 .Should()
                 .BeFalse();

            "test".IsMatch( actual )
                  .Should()
                  .BeFalse();
        }

        [Fact]
        public void WildcardToRegexTest3()
        {
            var actual = "*".WildcardToRegex();

            actual.Should()
                  .Be( "^.*$" );

            "".IsMatch( actual )
              .Should()
              .BeTrue();

            "test".IsMatch( actual )
                  .Should()
                  .BeTrue();

            "C:\\Temp\\txt.test".IsMatch( actual )
                                .Should()
                                .BeTrue();

            "txt*".IsMatch( actual )
                  .Should()
                  .BeTrue();

            "txt".IsMatch( actual )
                 .Should()
                 .BeTrue();

            "test".IsMatch( actual )
                  .Should()
                  .BeTrue();
        }

        [Fact]
        public void WildcardToRegexTest4()
        {
            var actual = "t?st".WildcardToRegex();

            actual.Should()
                  .Be( "^t.st$" );

            "test".IsMatch( actual )
                  .Should()
                  .BeTrue();

            "t?st".IsMatch( actual )
                  .Should()
                  .BeTrue();

            "t*st".IsMatch( actual )
                  .Should()
                  .BeTrue();

            "teest".IsMatch( actual )
                   .Should()
                   .BeFalse();

            "".IsMatch( actual )
              .Should()
              .BeFalse();

            "t??st".IsMatch( actual )
                   .Should()
                   .BeFalse();
        }

        [Fact]
        public void WildcardToRegexTest5()
        {
            var actual = "?est".WildcardToRegex();

            actual.Should()
                  .Be( "^.est$" );

            "test".IsMatch( actual )
                  .Should()
                  .BeTrue();

            "?est".IsMatch( actual )
                  .Should()
                  .BeTrue();

            "*est".IsMatch( actual )
                  .Should()
                  .BeTrue();

            "ttest".IsMatch( actual )
                   .Should()
                   .BeFalse();

            "".IsMatch( actual )
              .Should()
              .BeFalse();

            "??est".IsMatch( actual )
                   .Should()
                   .BeFalse();
        }

        [Fact]
        public void WildcardToRegexTest6()
        {
            var actual = "tes?".WildcardToRegex();

            actual.Should()
                  .Be( "^tes.$" );

            "test".IsMatch( actual )
                  .Should()
                  .BeTrue();

            "tes?".IsMatch( actual )
                  .Should()
                  .BeTrue();

            "tes*".IsMatch( actual )
                  .Should()
                  .BeTrue();

            "testt".IsMatch( actual )
                   .Should()
                   .BeFalse();

            "".IsMatch( actual )
              .Should()
              .BeFalse();

            "tes??".IsMatch( actual )
                   .Should()
                   .BeFalse();
        }

        [Fact]
        public void WildcardToRegexTestArgumentNullReference()
        {
            String pattern = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => pattern.WildcardToRegex();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}