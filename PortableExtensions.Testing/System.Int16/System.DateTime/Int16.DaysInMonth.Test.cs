#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [Test]
        public void DaysInMonthTestCase ()
        {
            var year = RandomValueEx.GetRandomInt32( 1990, 2015 );
            var month = RandomValueEx.GetRandomInt32( 1, 12 );

            var expected = DateTime.DaysInMonth( year, month );
            var actual = ( (Int16) year ).DaysInMonth( (Int16) month );
            Assert.AreEqual( expected, actual );
        }
    }
}