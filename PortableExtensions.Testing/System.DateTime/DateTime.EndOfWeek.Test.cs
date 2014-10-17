#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [Test]
        public void EndOfWeekTestCase ()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var expected = new DateTime( 2014, 3, 30 ).AddDays( 1 ).Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfWeek();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void EndOfWeekTestCase1 ()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var expected = new DateTime( 2014, 3, 31 ).AddDays( 1 ).Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfWeek( DayOfWeek.Monday );
            Assert.AreEqual( expected, actual );
        }
    }
}