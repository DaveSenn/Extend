#region Usings

using System;
using System.Globalization;
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
            Char result;
            var actual = "InvalidValue".TryParsChar( out result );

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
            Char result;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsChar( out result );

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
            Char result;
            var actual = expected.ToString( )
                                 .TryParsChar( out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}