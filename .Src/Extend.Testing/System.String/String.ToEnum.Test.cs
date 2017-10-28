#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void ToEnumTest()
        {
            const DayOfWeek expected = DayOfWeek.Monday;
            var actual = expected.ToString()
                                 .ToEnum<DayOfWeek>();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToEnumTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ToEnum<DayOfWeek>( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}