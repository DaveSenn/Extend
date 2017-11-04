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
        public void ToLongTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "T" );
            var actual = dateTime.ToLongTimeString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToLongTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "T", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToLongTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToLongTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "T", CultureInfo.InvariantCulture );
            var actual = dateTime.ToLongTimeString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}