#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [TestCase]
        public void DaysInMonthTestCase()
        {
            var year = RandomValueEx.GetRandomInt32( 1990, 2015 );
            var month = RandomValueEx.GetRandomInt32( 1, 12 );

            var expected = DateTime.DaysInMonth( year, month );
            var actual = year.DaysInMonth( month );
            Assert.AreEqual( expected, actual );
        }
    }
}