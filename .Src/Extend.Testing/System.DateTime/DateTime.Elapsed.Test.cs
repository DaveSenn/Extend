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
        public void ElapsedTest()
        {
            var dateTime = new DateTime( 1980, 1, 1 );
            var expected = DateTime.Now - dateTime;
            var actual = dateTime.Elapsed();

            //remove milliseconds
            expected = new TimeSpan( expected.Days, expected.Hours, expected.Minutes, expected.Seconds );
            actual = new TimeSpan( actual.Days, actual.Hours, actual.Minutes, actual.Seconds );
            Assert.AreEqual( expected, actual );
        }
    }
}