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
        public void ToInt32InvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "InvalidFormat".ToInt32();

            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToInt32NullTest()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt32();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToInt32OverloadFormatNullTest()
        {
            CultureInfo formatProvider = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".ToInt32( formatProvider );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToInt32OverloadInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "InvalidFormat".ToInt32( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToInt32OverloadNullTest()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt32( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToInt32OverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var value = RandomValueEx.GetRandomInt32();
            var actual = value.ToString( culture )
                              .ToInt32( culture );

            actual
                .Should()
                .Be( value );
        }

        [Fact]
        public void ToInt32OverloadValueToBigTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "123123123123".ToInt32( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToInt32OverloadValueToSmallTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "-123123123123".ToInt32( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToInt32Test()
        {
            var value = RandomValueEx.GetRandomInt32();
            var actual = value.ToString()
                              .ToInt32();

            actual
                .Should()
                .Be( value );
        }

        [Fact]
        public void ToInt32ValueToBigTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "123123123123".ToInt32();

            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToInt32ValueToSmallTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "-123123123123".ToInt32();

            test.ShouldThrow<OverflowException>();
        }
    }
}