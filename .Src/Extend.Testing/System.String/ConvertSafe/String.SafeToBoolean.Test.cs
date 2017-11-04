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
        public void SafeToBooleanInvalidValueTest()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = "InvalidValue".SafeToBoolean( expected );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void SafeToBooleanNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToBoolean();

            actual
                .Should()
                .Be( default(Boolean) );
        }

        [Fact]
        public void SafeToBooleanNullTest1()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToBoolean( !default(Boolean) );

            actual
                .Should()
                .Be( !default(Boolean) );
        }

        [Fact]
        public void SafeToBooleanTest()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = expected.ToString()
                                 .SafeToBoolean();

            actual
                .Should()
                .Be( expected );
        }
    }
}