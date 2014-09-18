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
        public void StartOfWeekTestCase()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var expected = new DateTime( 2014, 3, 24 );
            var actual = dateTime.StartOfWeek();

            Assert.AreEqual( expected, actual );

            expected = new DateTime( 2014, 3, 26 );
            actual = dateTime.StartOfWeek( DayOfWeek.Wednesday );

            Assert.AreEqual( expected, actual );
        }
    }
}