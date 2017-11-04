#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void SafeToDateTimeInvalidValueTest()
        {
            var expected = DateTime.Now;
            var actual = "InvalidValue".SafeToDateTime( expected );

            actual
                .Should()
                .BeCloseTo( expected, 999 );
        }

        [Fact]
        public void SafeToDateTimeInvalidValueTest1()
        {
            var expected = default(DateTime);
            var actual = "InvalidValue".SafeToDateTime();

            actual
                .Should()
                .BeCloseTo( expected, 999 );
        }

        [Fact]
        public void SafeToDateTimeNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToDateTime();

            actual
                .Should()
                .Be( default(DateTime) );
        }

        [Fact]
        public void SafeToDateTimeOverloadFormatProviderNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => DateTime.Now.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                        .SafeToDateTime( null, DateTimeStyles.AdjustToUniversal );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SafeToDateTimeOverloadInvalidDateTimeStyleTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => DateTime.Now.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                        .SafeToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SafeToDateTimeOverloadInvalidValueTest()
        {
            var expected = DateTime.Now;
            var actual = "InvalidValue".SafeToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDateTimeOverloadInvalidValueTest1()
        {
            var expected = default(DateTime);
            var actual = "InvalidValue".SafeToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDateTimeOverloadNullTest()
        {
            String value = null;
            var expected = DateTime.Now;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDateTimeOverloadTest()
        {
            var expected = DateTime.Now;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None );

            actual
                .Should()
                .BeCloseTo( expected, 999 );
        }

        [Fact]
        public void SafeToDateTimeOverloadTest1()
        {
            var expected = DateTime.Now;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, DateTime.MinValue );

            actual
                .Should()
                .BeCloseTo( expected, 999 );
        }

        [Fact]
        public void SafeToDateTimeTest()
        {
            var expected = DateTime.Now;
            expected = new DateTime( expected.Year, expected.Month, expected.Day, expected.Hour, expected.Second, 10 );
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .SafeToDateTime();

            actual
                .Should()
                .BeCloseTo( expected, 999 );
        }

        [Fact]
        public void SafeToDateTimeWithDefaultTest()
        {
            var expected = DateTime.Now;
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .SafeToDateTime( RandomValueEx.GetRandomDateTime() );

            actual
                .Should()
                .BeCloseTo( expected, 999 );
        }
    }
}