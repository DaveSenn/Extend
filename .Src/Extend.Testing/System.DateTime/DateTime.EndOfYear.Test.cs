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
        public void EndOfYearTestCase()
        {
            var dateTime = RandomValueEx.GetRandomDateTime( DateTime.Now, new DateTime( 3000, 1, 1 ) );
            var expected = new DateTime( dateTime.Year, 1, 1 ).AddYears( 1 )
                                                              .Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfYear();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void EndOfYearTestCase1()
        {
            var dateTime = new DateTime( 1, 1, 1 );
            var expected = new DateTime( dateTime.Year, 1, 1 ).AddYears( 1 )
                                                              .Subtract( 1.ToMilliseconds() );
            var actual = dateTime.EndOfYear();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void EndOfYearTestCase2()
        {
            var dateTime = new DateTime( 9999, 12, 31 );
            var expected = new DateTime( 9999, 12, 31, 23, 59, 59, 999 );
            var actual = dateTime.EndOfYear();
            Assert.AreEqual( expected, actual );
        }
    }
}