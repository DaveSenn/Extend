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
        public void IsWeekdDayTestCase()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var actual = dateTime.IsWeekdDay();
            Assert.IsTrue( actual );

            dateTime = new DateTime( 2014, 3, 29 );
            actual = dateTime.IsWeekdDay();
            Assert.IsFalse( actual );
        }
    }
}