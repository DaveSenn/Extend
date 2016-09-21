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
        public void ToDaysTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromDays( value );
            var actual = value.ToDays();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToDaysTooLargeTest()
        {
            var value = TimeSpan.MaxValue.Days + 1;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDays();

            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToDaysTooSmallTest()
        {
            var value = TimeSpan.MinValue.Days - 1;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDays();

            test.ShouldThrow<OverflowException>();
        }
    }
}