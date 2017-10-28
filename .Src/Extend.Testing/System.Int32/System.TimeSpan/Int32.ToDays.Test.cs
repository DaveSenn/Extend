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
        public void ToDaysTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromDays( value );
            var actual = value.ToDays();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToDaysTooLargeTest()
        {
            var value = TimeSpan.MaxValue.Days + 1;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDays();

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToDaysTooSmallTest()
        {
            var value = TimeSpan.MinValue.Days - 1;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDays();

            test.ShouldThrow<OverflowException>();
        }
    }
}