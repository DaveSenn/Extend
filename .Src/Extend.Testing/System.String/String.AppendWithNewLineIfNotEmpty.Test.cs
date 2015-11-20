#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void AppendWithNewLineIfNotEmptyNullAppendTest3()
        {
            const String target = "test";
            const String append = null;
            const String newLine = "</br>";

            var actual = target.AppendWithNewLineIfNotEmpty( append, newLine );

            actual.Should()
                  .Be( target + newLine );
        }

        [Test]
        public void AppendWithNewLineIfNotEmptyNullTargetTest3()
        {
            const String target = null;
            const String append = "asdf";
            const String newLine = "</br>";

            var actual = target.AppendWithNewLineIfNotEmpty( append, newLine );

            actual.Should()
                  .Be( append );
        }

        [Test]
        public void AppendWithNewLineIfNotEmptyTest()
        {
            const String target = "test-";
            const String append = "asdf";

            var actual = target.AppendWithNewLineIfNotEmpty( append );

            actual.Should()
                  .Be( target + Environment.NewLine + append );
        }

        [Test]
        public void AppendWithNewLineIfNotEmptyTest1()
        {
            const String target = "test-";
            const String append = "asdf";
            const String newLine = "</br>";

            var actual = target.AppendWithNewLineIfNotEmpty( append, newLine );

            actual.Should()
                  .Be( target + newLine + append );
        }

        [Test]
        public void AppendWithNewLineIfNotEmptyTest2()
        {
            const String target = "";
            const String append = "asdf";

            var actual = target.AppendWithNewLineIfNotEmpty( append );

            actual.Should()
                  .Be( append );
        }

        [Test]
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