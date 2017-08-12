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
            var actual = "InvalidValue".TryParsGuid(out Guid result);

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
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsGuid( out Guid result );

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
            var actual = expected.ToString()
                     .TryParsGuid(out Guid result);

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}