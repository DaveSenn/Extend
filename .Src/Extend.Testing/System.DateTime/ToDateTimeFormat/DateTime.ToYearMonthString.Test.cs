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
        public void ToYearMonthStringTest()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "y" );
            var actual = dateTime.ToYearMonthString();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToYearMonthStringTest1()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "y", DateTimeFormatInfo.CurrentInfo );
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = dateTime.ToYearMonthString( DateTimeFormatInfo.CurrentInfo );
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void ToYearMonthStringTest2()
        {
            var dateTime = DateTime.Now;
            var expected = dateTime.ToString( "y", CultureInfo.InvariantCulture );
            var actual = dateTime.ToYearMonthString( CultureInfo.InvariantCulture );
            Assert.Equal( expected, actual );
        }
    }
}