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
        public void TryParsCharInvalidValueTest()
        {
            var actual = "InvalidValue".TryParsChar( out var result );

            result
                .Should()
                .Be( default(Char) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsCharNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsChar( out var result );

            result
                .Should()
                .Be( default(Char) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsCharTest()
        {
            const Char expected = 'b';
            var actual = expected.ToString()
                                 .TryParsChar( out var result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}