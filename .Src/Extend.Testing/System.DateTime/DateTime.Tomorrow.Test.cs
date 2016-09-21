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
        public void TomorrowTest()
        {
            var dateTime = DateTime.Today;
            var expected = dateTime.AddDays( 1 );
            var actual = dateTime.Tomorrow();

            Assert.AreEqual( expected, actual );
        }
    }
}