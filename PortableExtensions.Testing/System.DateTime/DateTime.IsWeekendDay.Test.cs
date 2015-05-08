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
        public void IsWeekendDayTestCase()
        {
            var dateTime = new DateTime( 2014, 3, 27 );
            var actual = dateTime.IsWeekendDay();
            Assert.IsFalse( actual );

            dateTime = new DateTime( 2014, 3, 29 );
            actual = dateTime.IsWeekendDay();
            Assert.IsTrue( actual );
        }
    }
}