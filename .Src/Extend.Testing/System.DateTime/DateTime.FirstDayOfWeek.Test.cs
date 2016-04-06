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
        public void FirstDayOfWeekTest()
        {
            var dateTime = RandomValueEx.GetRandomDateTime();
            var expected =
                new DateTime( dateTime.Year, dateTime.Month, dateTime.Day ).AddDays( -(Int32) dateTime.DayOfWeek );
            var actual = dateTime.FirstDayOfWeek();
            Assert.AreEqual( expected, actual );
        }
    }
}