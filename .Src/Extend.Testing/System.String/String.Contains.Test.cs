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
        public void ContainsTest()
        {
            const String target = "this is my string";
            var actual = target.Contains( "string", StringComparison.OrdinalIgnoreCase );

            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void ContainsTest1()
        {
            const String target = "this is my string";
            var actual = target.Contains( "String", StringComparison.Ordinal );

            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void ContainsTest2()
        {
            const String target = "this is my String";
            var actual = target.Contains( "String", StringComparison.Ordinal );

            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void ContainsTestArgumentNullException()
        {
            const String target = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => target.Contains( "String", StringComparison.Ordinal );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsTestArgumentNullException1()
        {
            const String target = "my string";

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => target.Contains( null, StringComparison.Ordinal );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}