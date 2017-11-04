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
        public void SaveToGuidInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToGuid();

            actual
                .Should()
                .Be( default(Guid) );
        }

        [Fact]
        public void SaveToGuidInvalidValueWithDefaultTest()
        {
            var expected = Guid.NewGuid();
            var actual = "InvalidValue".SaveToGuid( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToGuidNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToGuid();

            actual
                .Should()
                .Be( default(Guid) );
        }

        [Fact]
        public void SaveToGuidNullWitDefaultTest()
        {
            var expected = Guid.NewGuid();
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToGuid( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToGuidTest()
        {
            var expected = Guid.NewGuid();
            var actual = expected.ToString()
                                 .SaveToGuid();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToGuidWithDefaultTest()
        {
            var expected = Guid.NewGuid();
            var actual = expected.ToString()
                                 .SaveToGuid( Guid.NewGuid() );

            actual
                .Should()
                .Be( expected );
        }
    }
}