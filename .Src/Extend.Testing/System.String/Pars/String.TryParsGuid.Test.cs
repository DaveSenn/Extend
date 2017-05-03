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
        public void TryParsGuidInvalidValueTest()
        {
            Guid result;
            var actual = "InvalidValue".TryParsGuid( out result );

            result
                .Should()
                .Be( default(Guid) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsGuidNullTest()
        {
            Guid result;
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsGuid( out result );

            result
                .Should()
                .Be( default(Guid) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsGuidTest()
        {
            var expected = Guid.NewGuid();
            Guid result;
            var actual = expected.ToString()
                                 .TryParsGuid( out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}