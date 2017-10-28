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
        public void ToShortTimeStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "t" );
            var actual = dateTime.ToShortTimeString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToShortTimeStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "t", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToShortTimeString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToShortTimeStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "t", CultureInfo.InvariantCulture );
            var actual = dateTime.ToShortTimeString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}