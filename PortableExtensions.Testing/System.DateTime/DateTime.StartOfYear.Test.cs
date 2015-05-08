#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [Test]
        public void StartOfYearTestCase()
        {
            var dateTime = DateTime.Today;
            var expected = new DateTime( dateTime.Year, 1, 1 );
            var actual = dateTime.StartOfYear();

            Assert.AreEqual( expected, actual );
        }
    }
}