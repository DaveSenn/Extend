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
        public void GetValuesExpectTest()
        {
            var actual = EnumEx.GetValuesExpect( DayOfWeek.Sunday, DayOfWeek.Thursday )
                               .ToList();

            Assert.Equal( 5, actual.Count );
            Assert.Equal( DayOfWeek.Monday, actual[0] );
            Assert.Equal( DayOfWeek.Tuesday, actual[1] );
            Assert.Equal( DayOfWeek.Wednesday, actual[2] );
            Assert.Equal( DayOfWeek.Friday, actual[3] );
            Assert.Equal( DayOfWeek.Saturday, actual[4] );
        }

        [Fact]
        public void GetValuesExpectTest1()
        {
            var actual = EnumEx.GetValuesExpect<DayOfWeek>( null )
                               .ToList();

            Assert.Equal( 7, actual.Count );
            Assert.Equal( DayOfWeek.Sunday, actual[0] );
            Assert.Equal( DayOfWeek.Monday, actual[1] );
            Assert.Equal( DayOfWeek.Tuesday, actual[2] );
            Assert.Equal( DayOfWeek.Wednesday, actual[3] );
            Assert.Equal( DayOfWeek.Thursday, actual[4] );
            Assert.Equal( DayOfWeek.Friday, actual[5] );
            Assert.Equal( DayOfWeek.Saturday, actual[6] );
        }

        [Fact]
        public void GetValuesExpectTest2()
        {
            var type = typeof(DayOfWeek);
            var actual = EnumEx.GetValuesExpect( type, DayOfWeek.Sunday, DayOfWeek.Thursday );

            var casted = actual.Cast<Object>();
            var list = casted.Select( x => Convert.ChangeType( x, type ) )
                             .ToList();

            Assert.Equal( 5, list.Count );
            Assert.Equal( DayOfWeek.Monday, list[0] );
            Assert.Equal( DayOfWeek.Tuesday, list[1] );
            Assert.Equal( DayOfWeek.Wednesday, list[2] );
            Assert.Equal( DayOfWeek.Friday, list[3] );
            Assert.Equal( DayOfWeek.Saturday, list[4] );
        }

        [Fact]
        public void GetValuesExpectTest3()
        {
            var type = typeof(DayOfWeek);
            var param = new Object[0];
            var actual = EnumEx.GetValuesExpect( type, param );

            var casted = actual.Cast<Object>();
            var list = casted.Select( x => Convert.ChangeType( x, type ) )
                             .ToList();

            Assert.Equal( 7, list.Count );
            Assert.Equal( DayOfWeek.Sunday, list[0] );
            Assert.Equal( DayOfWeek.Monday, list[1] );
            Assert.Equal( DayOfWeek.Tuesday, list[2] );
            Assert.Equal( DayOfWeek.Wednesday, list[3] );
            Assert.Equal( DayOfWeek.Thursday, list[4] );
            Assert.Equal( DayOfWeek.Friday, list[5] );
            Assert.Equal( DayOfWeek.Saturday, list[6] );
        }

        [Fact]
        public void GetValuesExpectTestArgumentExceptionCheck()
        {
            Action test = () => EnumEx.GetValuesExpect( 0, 4, 5 )
                                      // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                      .ToList();

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetValuesExpectTestArgumentExceptionCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => EnumEx.GetValuesExpect( typeof(Int32), 2, 3, 4, 5 );

            test.ShouldThrow<ArgumentException>();
        }
    }
}