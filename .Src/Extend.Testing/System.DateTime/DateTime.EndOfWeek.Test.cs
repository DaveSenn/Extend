#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [Test]
        public void EndOfWeekTest()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var expected = new DateTime( 2014, 3, 30 ).AddDays( 1 )
                                                      .Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfWeek();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void EndOfWeekTest1()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var expected = new DateTime( 2014, 3, 31 ).AddDays( 1 )
                                                      .Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfWeek( DayOfWeek.Monday );
            Assert.AreEqual( expected, actual );
        }
    }
}