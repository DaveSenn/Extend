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
        public void StartOfWeekTest()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var expected = new DateTime( 2014, 3, 24 );
            var actual = dateTime.StartOfWeek();

            Assert.AreEqual( expected, actual );

            expected = new DateTime( 2014, 3, 26 );
            actual = dateTime.StartOfWeek( DayOfWeek.Wednesday );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void StartOfWeekTest1()
        {
            var dateTime = new DateTime( 2014, 3, 27 );

            var expected = new DateTime( 2014, 3, 26 );
            var actual = dateTime.StartOfWeek( DayOfWeek.Wednesday );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void StartOfWeekTest2()
        {
            var week = new DateTime( 2014, 09, 21 );
            var expected = new DateTime( 2014, 09, 20 );
            var actual = week.StartOfWeek( DayOfWeek.Saturday );

            Assert.AreEqual( expected, actual );
        }
    }
}