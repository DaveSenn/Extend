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
        public void ToDaysTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromDays( value );
            var actual = ( (Int64) value ).ToDays();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToDaysTooLargeTest()
        {
            var value = (Int64) ( TimeSpan.MaxValue.Days + 1 );
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDays();

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToDaysTooSmallTest()
        {
            var value = (Int64) ( TimeSpan.MinValue.Days - 1 );
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDays();

            test.ShouldThrow<OverflowException>();
        }
    }
}