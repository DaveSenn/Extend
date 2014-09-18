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
        public void IntersectsTestCase()
        {
            var startDate = new DateTime( 1980, 1, 1 );
            var endDate = new DateTime( 1985, 1, 1 );

            var startDate2 = new DateTime( 1982, 1, 1 );
            var endDate2 = new DateTime( 1984, 1, 1 );

            var actual = startDate.Intersects( endDate, startDate2, endDate2 );
            Assert.IsTrue( actual );

            startDate = new DateTime( 1980, 1, 1 );
            endDate = new DateTime( 1985, 1, 1 );

            startDate2 = new DateTime( 1986, 1, 1 );
            endDate2 = new DateTime( 1989, 1, 1 );

            actual = startDate.Intersects( endDate, startDate2, endDate2 );
            Assert.IsFalse( actual );
        }
    }
}