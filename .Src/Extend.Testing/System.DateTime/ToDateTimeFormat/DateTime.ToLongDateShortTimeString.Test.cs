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
        public void ToLongDateShortTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "f" );
            var actual = dateTime.ToLongDateShortTimeString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToLongDateShortTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "f", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToLongDateShortTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToLongDateShortTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "f", CultureInfo.InvariantCulture );
            var actual = dateTime.ToLongDateShortTimeString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}