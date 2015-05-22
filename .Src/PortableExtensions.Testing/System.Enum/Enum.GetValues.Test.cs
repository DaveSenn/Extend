#region Usings

using System;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class EnumExTest
    {
        [Test]
        public void GetValuesTestCase()
        {
            var actual = EnumEx.GetValues<DayOfWeek>()
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
        public void GetValuesTestCase1()
        {
            var type = typeof (DayOfWeek);
            var actual = EnumEx.GetValues( type );

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
        [ExpectedException( typeof (ArgumentException) )]
        public void GetValuesTestCaseArgumentExceptionCheck()
        {
            EnumEx.GetValues<Int32>()
                  .ToList();
        }

        [Test]
        [ExpectedException( typeof (ArgumentException) )]
        public void GetValuesTestCaseArgumentExceptionCheck1()
        {
            EnumEx.GetValues( typeof (Int32) );
        }
    }
}