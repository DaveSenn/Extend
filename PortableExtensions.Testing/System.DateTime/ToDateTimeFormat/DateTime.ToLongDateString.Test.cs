#region Usings

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
        public void ToLongDateStringTestCase ()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "D" );
            var actual = DateTimeEx.ToLongDateString( dateTime );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToLongDateStringTestCase1 ()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "D", DateTimeFormatInfo.CurrentInfo );
            var actual = dateTime.ToLongDateString( DateTimeFormatInfo.CurrentInfo );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToLongDateStringTestCase2 ()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "D", CultureInfo.InvariantCulture );
            var actual = dateTime.ToLongDateString( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }
    }
}