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
        public void SaveToCharInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToChar();

            actual
                .Should()
                .Be( default(Char) );
        }

        [Fact]
        public void SaveToCharInvalidValueWithDefaultTest()
        {
            const Char expected = 'a';
            var actual = "InvalidValue".SaveToChar( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToCharNullTest()
        {
            String value = null;
            const Char expected = 'y';
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToChar( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToCharTest()
        {
            const Char expected = 'c';
            var actual = expected.ToString(  )
                                 .SaveToChar();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToCharTest1()
        {
            const Char expected = 'c';
            var actual = expected.ToString(  )
                                 .SaveToChar( 'e' );

            actual
                .Should()
                .Be( expected );
        }
    }
}