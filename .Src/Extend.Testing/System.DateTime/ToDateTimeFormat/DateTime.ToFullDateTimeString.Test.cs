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
        public void ToFullDateTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "F" );
            var actual = dateTime.ToFullDateTimeString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToFullDateTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "F", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToFullDateTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToFullDateTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "F", CultureInfo.InvariantCulture );
            var actual = dateTime.ToFullDateTimeString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}