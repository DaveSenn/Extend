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
        public void TryParsBooleanInvalidValueTest()
        {
            Boolean outValue;
            var actual = "InvalidValue".TryParsBoolean( out outValue );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsBooleanNullTest()
        {
            Boolean outValue;
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsBoolean( out outValue );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsBooleanTest()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            // ReSharper disable once RedundantAssignment
            var outValue = !expected;
            var actual = expected.ToString(  )
                                 .TryParsBoolean( out outValue );

            actual
                .Should()
                .BeTrue();

            outValue
                .Should()
                .Be( expected );
        }
    }
}