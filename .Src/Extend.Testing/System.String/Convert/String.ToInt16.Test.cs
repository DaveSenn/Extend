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
        public void ToInt16InvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "InvalidFormat".ToInt16();

            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToInt16NullTest()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt16OverloadFormatNullTest()
        {
            CultureInfo formatProvider = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".ToInt16( formatProvider );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt16OverloadInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "InvalidFormat".ToInt16( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToInt16OverloadNullTest()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt16OverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var value = RandomValueEx.GetRandomInt16();
            var actual = value.ToString( culture )
                              .ToInt16( culture );

            actual
                .Should()
                .Be( value );
        }

        [Test]
        public void ToInt16OverloadValueToBigTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "123123123123".ToInt16( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToInt16OverloadValueToSmallTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "-123123123123".ToInt16( new CultureInfo( "de-CH" ) );

            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToInt16Test()
        {
            var value = RandomValueEx.GetRandomInt16();
            var actual = value.ToString()
                              .ToInt16();

            actual
                .Should()
                .Be( value );
        }

        [Test]
        public void ToInt16ValueToBigTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "123123123123".ToInt16();

            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToInt16ValueToSmallTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "-123123123123".ToInt16();

            test.ShouldThrow<OverflowException>();
        }
    }
}