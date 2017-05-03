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
        public void SaveToBooleanInvalidValueTest()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = "InvalidValue".SaveToBoolean( expected );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void SaveToBooleanNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToBoolean();

            actual
                .Should()
                .Be( default(Boolean) );
        }

        [Fact]
        public void SaveToBooleanNullTest1()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToBoolean( !default(Boolean) );

            actual
                .Should()
                .Be( !default(Boolean) );
        }

        [Fact]
        public void SaveToBooleanTest()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = expected.ToString()
                                 .SaveToBoolean();

            actual
                .Should()
                .Be( expected );
        }
    }
}