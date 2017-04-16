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
        public void TryParsInt32InvalidValueTest()
        {
            Int32 result;
            var actual = "InvalidValue".TryParsInt32( out result );

            result
                .Should()
                .Be( default(Int32) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt32NullTest()
        {
            Int32 result;
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsInt32( out result );

            result
                .Should()
                .Be( default(Int32) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt32OverloadFormatProviderNullTest()
        {
            var expected = RandomValueEx.GetRandomInt32();
            CultureInfo culture = null;
            Int32 result;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .TryParsInt32( NumberStyles.Any, culture, out result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsInt32OverloadInvalidNumberFormatTest()
        {
            Int32 result;
            var expected = RandomValueEx.GetRandomInt32();

            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .TryParsInt32( NumberStyles.AllowDecimalPoint | NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TryParsInt32OverloadInvalidValueTest()
        {
            Int32 result;
            var actual = "InvalidValue".TryParsInt32( NumberStyles.Any, new CultureInfo( "de-CH" ), out result );

            result
                .Should()
                .Be( default(Int32) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt32OverloadNullTest()
        {
            Int32 result;
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsInt32( NumberStyles.Any, new CultureInfo( "de-CH" ), out result );

            result
                .Should()
                .Be( default(Int32) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsInt32OverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var expected = RandomValueEx.GetRandomInt32();
            Int32 result;
            var actual = expected.ToString( culture )
                                 .TryParsInt32( NumberStyles.Any, culture, out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Fact]
        public void TryParsInt32Test()
        {
            var expected = RandomValueEx.GetRandomInt32();
            Int32 result;
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .TryParsInt32( out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}