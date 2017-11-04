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

        [Fact]
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

        [Fact]
        public void CompareOrdinalCaseTest()
        {
            var actual = "Test".CompareOrdinal( "Test" );
            Assert.True( actual );

            actual = "Test".CompareOrdinal( "test" );
            Assert.False( actual );

            actual = "Test".CompareOrdinal( "asdasd" );
            Assert.False( actual );
        }
    }
}