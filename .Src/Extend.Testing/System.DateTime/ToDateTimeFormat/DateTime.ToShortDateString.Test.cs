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
        public void ToShortDateStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "d" );
            var actual = dateTime.ToShortDateString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToShortDateStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "d", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToShortDateString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToShortDateStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "d", CultureInfo.InvariantCulture );
            var actual = dateTime.ToShortDateString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}