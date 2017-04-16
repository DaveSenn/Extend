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
        public void SaveToDateTimeInvalidValueTest()
        {
            var expected = DateTime.Now;
            var actual = "InvalidValue".SaveToDateTime( expected );

            actual
                .Should()
                .BeCloseTo( expected, 999 );
        }

        [Fact]
        public void SaveToDateTimeInvalidValueTest1()
        {
            var expected = default(DateTime);
            var actual = "InvalidValue".SaveToDateTime();

            actual
                .Should()
                .BeCloseTo( expected, 999 );
        }

        [Fact]
        public void SaveToDateTimeNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToDateTime();

            actual
                .Should()
                .Be( default(DateTime) );
        }

        [Fact]
        public void SaveToDateTimeOverloadFormatProviderNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => DateTime.Now.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                        .SaveToDateTime( null, DateTimeStyles.AdjustToUniversal );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SaveToDateTimeOverloadInvalidDateTimeStyleTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => DateTime.Now.ToString( CultureInfo.InvariantCulture )
                                        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                        .SaveToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SaveToDateTimeOverloadInvalidValueTest()
        {
            var expected = DateTime.Now;
            var actual = "InvalidValue".SaveToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToDateTimeOverloadInvalidValueTest1()
        {
            var expected = default(DateTime);
            var actual = "InvalidValue".SaveToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToDateTimeOverloadNullTest()
        {
            String value = null;
            var expected = DateTime.Now;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToDateTimeOverloadTest()
        {
            var expected = DateTime.Now;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None );

            actual
                .Should()
                .BeCloseTo( expected, 999 );
        }

        [Fact]
        public void SaveToDateTimeOverloadTest1()
        {
            var expected = DateTime.Now;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, DateTime.MinValue );

            actual
                .Should()
                .BeCloseTo( expected, 999 );
        }

        [Fact]
        public void SaveToDateTimeTest()
        {
            var expected = DateTime.Now;
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .SaveToDateTime();

            actual
                .Should()
                .BeCloseTo( expected, 999 );
        }

        [Fact]
        public void SaveToDateTimeWithDefaultTest()
        {
            var expected = DateTime.Now;
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .SaveToDateTime( RandomValueEx.GetRandomDateTime() );

            actual
                .Should()
                .BeCloseTo( expected, 999 );
        }
    }
}