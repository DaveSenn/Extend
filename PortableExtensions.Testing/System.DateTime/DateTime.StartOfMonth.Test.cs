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
        public void StartOfMonthTestCase()
        {
            var dateTime = DateTime.Today;
            var expected = new DateTime( dateTime.Year, dateTime.Month, 1 );
            var actual = dateTime.StartOfMonth();

            Assert.AreEqual( expected, actual );
        }
    }
}