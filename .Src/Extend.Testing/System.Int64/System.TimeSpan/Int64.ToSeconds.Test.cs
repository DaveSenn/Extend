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
        public void ToSecondsTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromSeconds( value );
            var actual = ( (Int64) value ).ToSeconds();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToSecondsTooLargeTest()
        {
            const Int64 value = Int64.MaxValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToSeconds();

            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToSecondsTooSmallTest()
        {
            const Int64 value = Int64.MinValue;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToSeconds();

            test.ShouldThrow<OverflowException>();
        }
    }
}