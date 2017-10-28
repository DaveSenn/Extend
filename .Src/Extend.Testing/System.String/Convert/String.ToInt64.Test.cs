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
        public void ToInt64InvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "InvalidFormat".ToInt64();

            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToInt64NullTest()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt64();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToInt64OverloadFormatNullTest()
        {
            CultureInfo formatProvider = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".ToInt64( formatProvider );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToInt64OverloadInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "InvalidFormat".ToInt64( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToInt64OverloadNullTest()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt64( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToInt64OverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var value = RandomValueEx.GetRandomInt64();
            var actual = value.ToString( culture )
                              .ToInt64( culture );

            actual
                .Should()
                .Be( value );
        }

        [Fact]
        public void ToInt64OverloadValueToBigTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "92233720316854775807".ToInt64( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToInt64OverloadValueToSmallTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "-92233720368354775807".ToInt64( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToInt64Test()
        {
            var value = RandomValueEx.GetRandomInt64();
            var actual = value.ToString()
                              .ToInt64();

            actual
                .Should()
                .Be( value );
        }

        [Fact]
        public void ToInt64ValueToBigTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "92233720368547758072".ToInt64();

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToInt64ValueToSmallTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "-92233720362854775807".ToInt64();

            test.ShouldThrow<OverflowException>();
        }
    }
}