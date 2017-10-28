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
        public void ToMillisecondsTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromMilliseconds( value );
            var actual = ( (Int64) value ).ToMilliseconds();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToMillisecondsTooLargeTest()
        {
            const Int64 value = Int64.MaxValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToMilliseconds();

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToMillisecondsTooSmallTest()
        {
            const Int64 value = Int64.MinValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToMilliseconds();

            test.ShouldThrow<OverflowException>();
        }
    }
}