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
        public void CompareOrdinalCaseNullTest()
        {
            var left = RandomValueEx.GetRandomString();
            String right = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = left.CompareOrdinal( right );
            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void CompareOrdinalCaseNullTest1()
        {
            String left = null;
            var right = RandomValueEx.GetRandomString();

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = left.CompareOrdinal( right );
            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void CompareOrdinalCaseTest()
        {
            var actual = "Test".CompareOrdinal( "Test" );
            Assert.IsTrue( actual );

            actual = "Test".CompareOrdinal( "test" );
            Assert.IsFalse( actual );

            actual = "Test".CompareOrdinal( "asdasd" );
            Assert.IsFalse( actual );
        }
    }
}