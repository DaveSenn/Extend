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
        public void NextWeekDayTestCase ()
        {
            var friday = new DateTime( 2014, 8, 8 );
            var saturday = new DateTime( 2014, 8, 9 );
            var sunday = new DateTime( 2014, 8, 10 );

            var actual = friday.NextWeekDay();
            Assert.AreEqual( friday, actual );

            actual = saturday.NextWeekDay();
            Assert.AreEqual( new DateTime( 2014, 8, 11 ), actual );

            actual = sunday.NextWeekDay();
            Assert.AreEqual( new DateTime( 2014, 8, 11 ), actual );
        }
    }
}