#region Usings

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class EnumExTest
    {
        [Fact]
        public void GetStringValuesTest()
        {
            var actual = EnumEx.GetStringValues<DayOfWeek>()
                               .ToList();
            Assert.Equal( 7, actual.Count );
            Assert.Equal( "Sunday", actual[0] );
            Assert.Equal( "Monday", actual[1] );
            Assert.Equal( "Tuesday", actual[2] );
            Assert.Equal( "Wednesday", actual[3] );
            Assert.Equal( "Thursday", actual[4] );
            Assert.Equal( "Friday", actual[5] );
            Assert.Equal( "Saturday", actual[6] );
        }

        [Fact]
        public void GetStringValuesTestArgumentExceptionCheck()
        {
            Action test = () => EnumEx.GetValues<Int32>()
                                      // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                      .ToList();

            test.ShouldThrow<ArgumentException>();
        }
    }
}