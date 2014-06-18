#region Using

using System;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class EnumExTest
    {
        [TestCase]
        public void GetValuesCaseTestCase()
        {
            var actual = EnumEx.GetValues<DayOfWeek>().ToList();
            Assert.AreEqual( 7, actual.Count );
            Assert.AreEqual( DayOfWeek.Sunday, actual[0] );
            Assert.AreEqual( DayOfWeek.Monday, actual[1] );
            Assert.AreEqual( DayOfWeek.Tuesday, actual[2] );
            Assert.AreEqual( DayOfWeek.Wednesday, actual[3] );
            Assert.AreEqual( DayOfWeek.Thursday, actual[4] );
            Assert.AreEqual( DayOfWeek.Friday, actual[5] );
            Assert.AreEqual( DayOfWeek.Saturday, actual[6] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentException ) )]
        public void GetValuesCaseTestCaseArgumentExceptionCheck()
        {
            EnumEx.GetValues<Int32>().ToList();
        }
    }
}