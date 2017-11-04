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
        public void SafeToCharInvalidValueTest()
        {
            var actual = "InvalidValue".SafeToChar();

            actual
                .Should()
                .Be( default(Char) );
        }

        [Fact]
        public void SafeToCharInvalidValueWithDefaultTest()
        {
            const Char expected = 'a';
            var actual = "InvalidValue".SafeToChar( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToCharNullTest()
        {
            String value = null;
            const Char expected = 'y';
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToChar( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToCharTest()
        {
            const Char expected = 'c';
            var actual = expected.ToString()
                                 .SafeToChar();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToCharTest1()
        {
            const Char expected = 'c';
            var actual = expected.ToString()
                                 .SafeToChar( 'e' );

            actual
                .Should()
                .Be( expected );
        }
    }
}