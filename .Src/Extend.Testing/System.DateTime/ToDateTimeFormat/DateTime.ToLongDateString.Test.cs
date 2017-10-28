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
        public void ToLongDateStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "D" );
            var actual = dateTime.ToLongDateString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToLongDateStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "D", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToLongDateString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToLongDateStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "D", CultureInfo.InvariantCulture );
            var actual = dateTime.ToLongDateString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}