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
        public void GetValueAndStringValueTest()
        {
            var actual = EnumEx.GetValueAndStringValue<DayOfWeek>()
                               .ToList();
            Assert.Equal( 7, actual.Count );

            Assert.Equal( "Sunday",
                          actual[0]
                              .Value );
            Assert.Equal( DayOfWeek.Sunday,
                          actual[0]
                              .Key );

            Assert.Equal( "Monday",
                          actual[1]
                              .Value );
            Assert.Equal( DayOfWeek.Monday,
                          actual[1]
                              .Key );

            Assert.Equal( "Tuesday",
                          actual[2]
                              .Value );
            Assert.Equal( DayOfWeek.Tuesday,
                          actual[2]
                              .Key );

            Assert.Equal( "Wednesday",
                          actual[3]
                              .Value );
            Assert.Equal( DayOfWeek.Wednesday,
                          actual[3]
                              .Key );

            Assert.Equal( "Thursday",
                          actual[4]
                              .Value );
            Assert.Equal( DayOfWeek.Thursday,
                          actual[4]
                              .Key );

            Assert.Equal( "Friday",
                          actual[5]
                              .Value );
            Assert.Equal( DayOfWeek.Friday,
                          actual[5]
                              .Key );

            Assert.Equal( "Saturday",
                          actual[6]
                              .Value );
            Assert.Equal( DayOfWeek.Saturday,
                          actual[6]
                              .Key );
        }

        [Fact]
        public void GetValueAndStringValueTestArgumentExceptionCheck()
        {
            Action test = () => EnumEx.GetValueAndStringValue<Int32>()
                                      // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                      .ToList();

            test.ShouldThrow<ArgumentException>();
        }
    }
}