#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [Test]
        public void ToFullDateTimeStringTestCase()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "F" );
            var actual = dateTime.ToFullDateTimeString();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToFullDateTimeStringTestCase1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "F", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToFullDateTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToFullDateTimeStringTestCase2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "F", CultureInfo.InvariantCulture );
            var actual = dateTime.ToFullDateTimeString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}