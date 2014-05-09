#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [TestCase]
        public void IsTodayTestCase()
        {
            var dateTime = DateTime.Now;
            var actual = dateTime.IsToday();
            Assert.IsTrue( actual );

            dateTime = DateTime.Now.AddDays( 2 );
            actual = dateTime.IsToday();
            Assert.IsFalse( actual );
        }
    }
}