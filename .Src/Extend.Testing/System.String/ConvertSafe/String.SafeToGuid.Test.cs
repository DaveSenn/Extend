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
        public void SafeToGuidInvalidValueTest()
        {
            var actual = "InvalidValue".SafeToGuid();

            actual
                .Should()
                .Be( default(Guid) );
        }

        [Fact]
        public void SafeToGuidInvalidValueWithDefaultTest()
        {
            var expected = Guid.NewGuid();
            var actual = "InvalidValue".SafeToGuid( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToGuidNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToGuid();

            actual
                .Should()
                .Be( default(Guid) );
        }

        [Fact]
        public void SafeToGuidNullWitDefaultTest()
        {
            var expected = Guid.NewGuid();
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToGuid( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToGuidTest()
        {
            var expected = Guid.NewGuid();
            var actual = expected.ToString()
                                 .SafeToGuid();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToGuidWithDefaultTest()
        {
            var expected = Guid.NewGuid();
            var actual = expected.ToString()
                                 .SafeToGuid( Guid.NewGuid() );

            actual
                .Should()
                .Be( expected );
        }
    }
}