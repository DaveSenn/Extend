#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void ToHoursTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromHours( value );
            var actual = value.ToHours();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToHoursTooLargeTest()
        {
            const Int32 value = Int32.MaxValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToHours();

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToHoursTooSmallTest()
        {
            const Int32 value = Int32.MinValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToHours();

            test.ShouldThrow<OverflowException>();
        }
    }
}