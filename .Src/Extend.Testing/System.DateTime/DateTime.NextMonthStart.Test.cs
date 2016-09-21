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
        public void NextMonthStartTest()
        {
            var dateTime = DateTime.Now;
            var actual = dateTime.NextMonthStart();

            var expected = dateTime.Month == 12
                ? new DateTime( dateTime.Year + 1, 1, 1 )
                : new DateTime( dateTime.Year, dateTime.Month + 1, 1 );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void NextMonthStartTest1()
        {
            var dateTime = new DateTime( 2014, 08, 12, 12, 12, 5 );
            var expected = new DateTime( 2014, 09, 01 );

            var actual = dateTime.NextMonthStart();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void NextMonthStartTest2()
        {
            var dateTime = new DateTime( 2014, 12, 12, 12, 12, 5 );
            var expected = new DateTime( 2015, 01, 01 );

            var actual = dateTime.NextMonthStart();
            Assert.AreEqual( expected, actual );
        }
    }
}