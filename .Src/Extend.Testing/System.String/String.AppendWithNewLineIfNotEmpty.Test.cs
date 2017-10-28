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
        public void AppendWithNewLineIfNotEmptyNullAppendTest3()
        {
            const String target = "test";
            const String append = null;
            const String newLine = "</br>";

            var actual = target.AppendWithNewLineIfNotEmpty( append, newLine );

            actual.Should()
                  .Be( target + newLine );
        }

        [Fact]
        public void AppendWithNewLineIfNotEmptyNullTargetTest3()
        {
            const String target = null;
            const String append = "asdf";
            const String newLine = "</br>";

            var actual = target.AppendWithNewLineIfNotEmpty( append, newLine );

            actual.Should()
                  .Be( append );
        }

        [Fact]
        public void AppendWithNewLineIfNotEmptyTest()
        {
            const String target = "test-";
            const String append = "asdf";

            var actual = target.AppendWithNewLineIfNotEmpty( append );

            actual.Should()
                  .Be( target + Environment.NewLine + append );
        }

        [Fact]
        public void AppendWithNewLineIfNotEmptyTest1()
        {
            const String target = "test-";
            const String append = "asdf";
            const String newLine = "</br>";

            var actual = target.AppendWithNewLineIfNotEmpty( append, newLine );

            actual.Should()
                  .Be( target + newLine + append );
        }

        [Fact]
        public void AppendWithNewLineIfNotEmptyTest2()
        {
            const String target = "";
            const String append = "asdf";

            var actual = target.AppendWithNewLineIfNotEmpty( append );

            actual.Should()
                  .Be( append );
        }

        [Fact]
        public void AppendWithNewLineIfNotEmptyTest3()
        {
            const String target = "";
            const String append = "asdf";
            const String newLine = "</br>";

            var actual = target.AppendWithNewLineIfNotEmpty( append, newLine );

            actual.Should()
                  .Be( append );
        }
    }
}