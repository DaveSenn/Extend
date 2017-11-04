#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int64ExTest
    {
        [Fact]
        public void ToMinutesTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromMinutes( value );
            var actual = ( (Int64) value ).ToMinutes();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToMinutesTooLargeTest()
        {
            const Int64 value = Int64.MaxValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToMinutes();

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToMinutesTooSmallTest()
        {
            const Int64 value = Int64.MinValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToMinutes();

            test.ShouldThrow<OverflowException>();
        }
    }
}