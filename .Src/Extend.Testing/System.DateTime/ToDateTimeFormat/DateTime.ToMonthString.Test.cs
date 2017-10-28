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
        public void ToMonthStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "MMMM" );
            var actual = dateTime.ToMonthString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToMonthStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "MMMM", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToMonthString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToMonthStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "MMMM", new CultureInfo( "de-CH" ) );
            var actual = dateTime.ToMonthString( new CultureInfo( "de-CH" ) );
            Assert.Equal( expected, actual );
        }
    }
}