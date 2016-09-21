#region Usings

using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class EnumExTest
    {
        [Test]
        public void GetValuesExpectTest()
        {
            var actual = EnumEx.GetValuesExpect( DayOfWeek.Sunday, DayOfWeek.Thursday )
                               .ToList();

            Assert.AreEqual( 5, actual.Count );
            Assert.AreEqual( DayOfWeek.Monday, actual[0] );
            Assert.AreEqual( DayOfWeek.Tuesday, actual[1] );
            Assert.AreEqual( DayOfWeek.Wednesday, actual[2] );
            Assert.AreEqual( DayOfWeek.Friday, actual[3] );
            Assert.AreEqual( DayOfWeek.Saturday, actual[4] );
        }

        [Test]
        public void GetValuesExpectTest1()
        {
            var actual = EnumEx.GetValuesExpect<DayOfWeek>( null )
                               .ToList();

            Assert.AreEqual( 7, actual.Count );
            Assert.AreEqual( DayOfWeek.Sunday, actual[0] );
            Assert.AreEqual( DayOfWeek.Monday, actual[1] );
            Assert.AreEqual( DayOfWeek.Tuesday, actual[2] );
            Assert.AreEqual( DayOfWeek.Wednesday, actual[3] );
            Assert.AreEqual( DayOfWeek.Thursday, actual[4] );
            Assert.AreEqual( DayOfWeek.Friday, actual[5] );
            Assert.AreEqual( DayOfWeek.Saturday, actual[6] );
        }

        [Test]
        public void GetValuesExpectTest2()
        {
            var type = typeof(DayOfWeek);
            var actual = EnumEx.GetValuesExpect( type, DayOfWeek.Sunday, DayOfWeek.Thursday );

            var casted = actual.Cast<Object>();
            var list = casted.Select( x => Convert.ChangeType( x, type ) )
                             .ToList();

            Assert.AreEqual( 5, list.Count );
            Assert.AreEqual( DayOfWeek.Monday, list[0] );
            Assert.AreEqual( DayOfWeek.Tuesday, list[1] );
            Assert.AreEqual( DayOfWeek.Wednesday, list[2] );
            Assert.AreEqual( DayOfWeek.Friday, list[3] );
            Assert.AreEqual( DayOfWeek.Saturday, list[4] );
        }

        [Test]
        public void GetValuesExpectTest3()
        {
            var type = typeof(DayOfWeek);
            var param = new Object[0];
            var actual = EnumEx.GetValuesExpect( type, param );

            var casted = actual.Cast<Object>();
            var list = casted.Select( x => Convert.ChangeType( x, type ) )
                             .ToList();

            Assert.AreEqual( 7, list.Count );
            Assert.AreEqual( DayOfWeek.Sunday, list[0] );
            Assert.AreEqual( DayOfWeek.Monday, list[1] );
            Assert.AreEqual( DayOfWeek.Tuesday, list[2] );
            Assert.AreEqual( DayOfWeek.Wednesday, list[3] );
            Assert.AreEqual( DayOfWeek.Thursday, list[4] );
            Assert.AreEqual( DayOfWeek.Friday, list[5] );
            Assert.AreEqual( DayOfWeek.Saturday, list[6] );
        }

        [Test]
        public void GetValuesExpectTestArgumentExceptionCheck()
        {
            Action test = () => EnumEx.GetValuesExpect( 0, 4, 5 )
                                      .ToList();

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void GetValuesExpectTestArgumentExceptionCheck1()
        {
            Action test = () => EnumEx.GetValuesExpect( typeof(Int32), 2, 3, 4, 5 );

            test.ShouldThrow<ArgumentException>();
        }
    }
}