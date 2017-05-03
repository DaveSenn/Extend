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
        public void TryToEnumTest()
        {
            const DayOfWeek expected = DayOfWeek.Monday;
            DayOfWeek actual;
            var result = StringEx.TryToEnum( expected.ToString(), out actual );

            actual
                .Should()
                .Be( expected );
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void TryToEnumTestNullCheck()
        {
            DayOfWeek day;
            var actual = StringEx.TryToEnum( null, out day );

            actual
                .Should()
                .BeFalse();
            day
                .Should()
                .Be( default(DayOfWeek) );
        }
    }
}