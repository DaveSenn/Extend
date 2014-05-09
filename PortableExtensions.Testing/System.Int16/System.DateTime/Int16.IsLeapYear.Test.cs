#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [TestCase]
        public void IsLeapYearTestCase()
        {
            var year = RandomValueEx.GetRandomInt32( 1990, 2015 );

            var expected = DateTime.IsLeapYear( year );
            var actual = ( (Int16) year ).IsLeapYear();
            Assert.AreEqual( expected, actual );
        }
    }
}