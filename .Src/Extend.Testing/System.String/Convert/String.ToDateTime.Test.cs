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

            Assert.Throws<FormatException>( test );
        }

        [Fact]
        public void ToDateTimeNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ToDateTime( null );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ToDateTimeOtherCultureTest()
        {
            var value = new DateTime( 2018, 05, 28, 12, 33, 11 );
            var actual = value.ToString( CultureInfo.InvariantCulture )
                              .ToDateTime();

            Assert.Equal( value, actual );
        }

        [Fact]
        public void ToDateTimeOverloadFormatNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => DateTime.Now.ToString( CultureInfo.InvariantCulture )
                                        .ToDateTime( null );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ToDateTimeOverloadInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "invalidFormat".ToDateTime( CultureInfo.CurrentCulture );

            Assert.Throws<FormatException>( test );
        }

        [Fact]
        public void ToDateTimeOverloadNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ToDateTime( null, CultureInfo.CurrentCulture );

            Assert.Throws<ArgumentNullException>( test );
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