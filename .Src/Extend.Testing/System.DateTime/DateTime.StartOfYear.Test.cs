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
        public void StartOfYearTest()
        {
            var dateTime = DateTime.Today;
            var expected = new DateTime( dateTime.Year, 1, 1 );
            var actual = dateTime.StartOfYear();

            Assert.AreEqual( expected, actual );
        }
    }
}