#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ToDecimalInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "InvalidFormat".ToDecimal();

            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToDecimalNullTest()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDecimalOverloadFormatNullTest()
        {
            CultureInfo formatProvider = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "10".ToDecimal( formatProvider );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDecimalOverloadInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "InvalidFormat".ToDecimal( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToDecimalOverloadNullTest()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDecimal( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDecimalOverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var value = new Decimal( 100.123 );
            var actual = value.ToString( culture )
                              .ToDecimal( culture );

            actual
                .Should()
                .Be( value );
        }

        [Test]
        public void ToDecimalOverloadValueToBigTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "79228162514264337593543950335222".ToDecimal( new CultureInfo( "de-CH" ) );
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToDecimalOverloadValueToSmallTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "-79228162514264337593543950335222".ToDecimal( new CultureInfo( "de-CH" ) );
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToDecimalTest()
        {
            var value = new Decimal( 100.123 );
            var actual = value.ToString( CultureInfo.CurrentCulture )
                              .ToDecimal();

            actual
                .Should()
                .Be( value );
        }

        [Test]
        public void ToDecimalValueToBigTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "79228162514264337593543950335222".ToDecimal();
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToDecimalValueToSmallTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "-79228162514264337593543950335222".ToDecimal();
            test.ShouldThrow<OverflowException>();
        }
    }
}