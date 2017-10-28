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
        public void ToHoursTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromHours( value );
            var actual = ( (Int64) value ).ToHours();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToHoursTooLargeTest()
        {
            const Int64 value = Int64.MaxValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToHours();

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToHoursTooSmallTest()
        {
            const Int64 value = Int64.MinValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToHours();

            test.ShouldThrow<OverflowException>();
        }
    }
}