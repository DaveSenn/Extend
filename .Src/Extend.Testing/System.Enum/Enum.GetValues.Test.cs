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
        public void GetValuesTest()
        {
            var actual = EnumEx.GetValues<DayOfWeek>()
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
        public void GetValuesTest1()
        {
            var type = typeof(DayOfWeek);
            var actual = EnumEx.GetValues( type );

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
        public void GetValuesTestArgumentExceptionCheck()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => EnumEx.GetValues<Int32>();

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetValuesTestArgumentExceptionCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => EnumEx.GetValues( typeof(Int32) );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void GetValuesTestArgumentNullException()
        {
            Type t = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => EnumEx.GetValues( t );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}