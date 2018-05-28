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
        public void ToBooleanInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "invalidValue".ToBoolean();

            Assert.Throws<FormatException>( test );
        }

        [Fact]
        public void ToBooleanNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ToBoolean( null );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ToBooleanTest()
        {
            var value = RandomValueEx.GetRandomBoolean();
            var actual = value.ToString()
                              .ToBoolean();

            actual
                .Should()
                .Be( value );
        }
    }
}