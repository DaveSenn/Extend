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
        public void IsOdd0Test()
        {
            const Int64 value = 0;

            var actual = value.IsOdd();
            actual.Should()
                  .BeFalse();
        }

        [Fact]
        public void IsOddTest()
        {
            var value = RandomValueEx.GetRandomInt32();

            var expected = value % 2 != 0;
            var actual = Int64Ex.IsOdd( value );
            Assert.Equal( expected, actual );
        }
    }
}