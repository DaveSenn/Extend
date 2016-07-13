#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [Test]
        public void ToHoursTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromHours( value );
            var actual = ( (Int64) value ).ToHours();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToHoursTooLargeTest()
        {
            const Int64 value = Int64.MaxValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToHours();

            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToHoursTooSmallTest()
        {
            const Int64 value = Int64.MinValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToHours();

            test.ShouldThrow<OverflowException>();
        }
    }
}