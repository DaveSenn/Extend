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
        public void GetStringValuesTestCase()
        {
            var actual = EnumEx.GetStringValues<DayOfWeek>()
                               .ToList();
            Assert.AreEqual( 7, actual.Count );
            Assert.AreEqual( "Sunday", actual[0] );
            Assert.AreEqual( "Monday", actual[1] );
            Assert.AreEqual( "Tuesday", actual[2] );
            Assert.AreEqual( "Wednesday", actual[3] );
            Assert.AreEqual( "Thursday", actual[4] );
            Assert.AreEqual( "Friday", actual[5] );
            Assert.AreEqual( "Saturday", actual[6] );
        }

        [Test]
        public void GetStringValuesTestCaseArgumentExceptionCheck()
        {
            Action test = () => EnumEx.GetValues<Int32>()
                                      .ToList();

            test.ShouldThrow<ArgumentException>();
        }
    }
}