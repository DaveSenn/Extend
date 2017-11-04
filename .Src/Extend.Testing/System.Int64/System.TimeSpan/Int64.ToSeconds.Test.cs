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
        public void ToSecondsTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromSeconds( value );
            var actual = ( (Int64) value ).ToSeconds();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToSecondsTooLargeTest()
        {
            const Int64 value = Int64.MaxValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToSeconds();

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToSecondsTooSmallTest()
        {
            const Int64 value = Int64.MinValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToSeconds();

            test.ShouldThrow<OverflowException>();
        }
    }
}