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
        public void IsSameMonthAndYearTestCase()
        {
            var dateTime = DateTime.Now;
            var otherDateTime = DateTime.Now;

            Assert.IsTrue( dateTime.IsSameMonthAndYear( otherDateTime ) );
        }

        [TestCase]
        public void IsSameMonthAndYearTestCase1()
        {
            var dateTime = new DateTime( 2014, 08, 10 );
            var otherDateTime = new DateTime( 2014, 08, 1 );

            Assert.IsTrue( dateTime.IsSameMonthAndYear( otherDateTime ) );
        }

        [TestCase]
        public void IsSameMonthAndYearTestCase2()
        {
            var dateTime = new DateTime( 2014, 08, 10 );
            var otherDateTime = new DateTime( 2014, 09, 1 );

            Assert.IsFalse( dateTime.IsSameMonthAndYear( otherDateTime ) );
        }

        [TestCase]
        public void IsSameMonthAndYearTestCase3()
        {
            var dateTime = new DateTime( 2014, 08, 10 );
            var otherDateTime = new DateTime( 2013, 08, 1 );

            Assert.IsFalse( dateTime.IsSameMonthAndYear( otherDateTime ) );
        }
    }
}