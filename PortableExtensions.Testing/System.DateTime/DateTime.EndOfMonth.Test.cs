#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [Test]
        public void EndOfMonthTestCase()
        {
            var dateTime = DateTime.Now;
            var expected = new DateTime( dateTime.Year, dateTime.Month, 1 ).AddMonths( 1 )
                                                                           .Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfMonth();
            Assert.AreEqual( expected, actual );
        }
    }
}