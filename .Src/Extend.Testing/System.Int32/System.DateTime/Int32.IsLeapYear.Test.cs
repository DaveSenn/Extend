#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void IsLeapYearTest()
        {
            var year = RandomValueEx.GetRandomInt32( 1990, 2015 );

            var expected = DateTime.IsLeapYear( year );
            var actual = year.IsLeapYear();
            Assert.AreEqual( expected, actual );
        }
    }
}