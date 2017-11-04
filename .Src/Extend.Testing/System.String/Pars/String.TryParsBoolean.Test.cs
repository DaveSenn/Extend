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
        public void TryParsBooleanInvalidValueTest()
        {
            var actual = "InvalidValue".TryParsBoolean( out Boolean _ );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsBooleanNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsBoolean( out Boolean _ );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsBooleanTest()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            // ReSharper disable once RedundantAssignment
            var actual = expected.ToString()
                                 .TryParsBoolean( out var outValue );

            actual
                .Should()
                .BeTrue();

            outValue
                .Should()
                .Be( expected );
        }
    }
}