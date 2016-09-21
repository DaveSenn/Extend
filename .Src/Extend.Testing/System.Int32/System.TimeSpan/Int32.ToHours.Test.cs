#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void ToHoursTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromHours( value );
            var actual = value.ToHours();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToHoursTooLargeTest()
        {
            const Int32 value = Int32.MaxValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToHours();

            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToHoursTooSmallTest()
        {
            const Int32 value = Int32.MinValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToHours();

            test.ShouldThrow<OverflowException>();
        }
    }
}