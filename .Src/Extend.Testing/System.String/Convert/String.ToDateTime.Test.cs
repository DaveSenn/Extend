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
        public void ToDateTimeInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "invalidFormat".ToDateTime();

            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToDateTimeNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ToDateTime( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToDateTimeOtherCultureTest()
        {
            var value = DateTime.Now;
            var actual = value.ToString( CultureInfo.InvariantCulture )
                              .ToDateTime();

            actual
                .Should()
                .BeCloseTo( value, 999 );
        }

        [Fact]
        public void ToDateTimeOverloadFormatNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => DateTime.Now.ToString( CultureInfo.InvariantCulture )
                                        .ToDateTime( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToDateTimeOverloadInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "invalidFormat".ToDateTime( CultureInfo.CurrentCulture );

            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToDateTimeOverloadNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ToDateTime( null, CultureInfo.CurrentCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToDateTimeOverloadOtherCultureTest()
        {
            var culture = new CultureInfo( "de-CH" );

            var value = DateTime.Now;
            var actual = value.ToString( culture )
                              .ToDateTime( culture );

            actual
                .Should()
                .BeCloseTo( value, 999 );
        }

        [Fact]
        public void ToDateTimeOverloadTest()
        {
            var value = DateTime.Now;
            var actual = value.ToString( CultureInfo.InvariantCulture )
                              .ToDateTime( CultureInfo.InvariantCulture );

            actual
                .Should()
                .BeCloseTo( value, 999 );
        }

        [Fact]
        public void ToDateTimeTest()
        {
            var value = DateTime.Now;
            var actual = value.ToString( CultureInfo.InvariantCulture )
                              .ToDateTime();

            actual
                .Should()
                .BeCloseTo( value, 999 );
        }
    }
}