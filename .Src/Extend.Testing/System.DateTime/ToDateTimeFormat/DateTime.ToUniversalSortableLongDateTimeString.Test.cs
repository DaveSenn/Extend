#region Usings

using System;
using System.Globalization;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void ToUniversalSortableLongDateTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "U" );
            var actual = dateTime.ToUniversalSortableLongDateTimeString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToUniversalSortableLongDateTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "U", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToUniversalSortableLongDateTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToUniversalSortableLongDateTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "U", CultureInfo.InvariantCulture );
            var actual = dateTime.ToUniversalSortableLongDateTimeString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}