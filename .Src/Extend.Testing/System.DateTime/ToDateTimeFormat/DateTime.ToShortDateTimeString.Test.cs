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
        public void ToShortDateTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "g" );
            var actual = dateTime.ToShortDateTimeString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToShortDateTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "g", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToShortDateTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToShortDateTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "g", CultureInfo.InvariantCulture );
            var actual = dateTime.ToShortDateTimeString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}