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
        public void TryParsInt16InvalidValueTest()
        {
            Int16 result;
            var actual = "InvalidValue".TryParsInt16( out result );

            result
                .Should()
                .Be( default(Int16) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsInt16NullTest()
        {
            Int16 result;
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsInt16( out result );

            result
                .Should()
                .Be( default(Int16) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsInt16OverloadFormatProviderNullTest()
        {
            var expected = RandomValueEx.GetRandomInt16();
            CultureInfo culture = null;
            Int16 result;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .TryParsInt16( NumberStyles.Any, culture, out result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsInt16OverloadInvalidNumberFormatTest()
        {
            Int16 result;
            var expected = RandomValueEx.GetRandomInt16();

            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .TryParsInt16( NumberStyles.AllowDecimalPoint | NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void TryParsInt16OverloadInvalidValueTest()
        {
            Int16 result;
            var actual = "InvalidValue".TryParsInt16( NumberStyles.Any, new CultureInfo( "de-CH" ), out result );

            result
                .Should()
                .Be( default(Int16) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsInt16OverloadNullTest()
        {
            Int16 result;
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsInt16( NumberStyles.Any, new CultureInfo( "de-CH" ), out result );

            result
                .Should()
                .Be( default(Int16) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsInt16OverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var expected = RandomValueEx.GetRandomInt16();
            Int16 result;
            var actual = expected.ToString( culture )
                                 .TryParsInt16( NumberStyles.Any, culture, out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Test]
        public void TryParsInt16Test()
        {
            var expected = RandomValueEx.GetRandomInt16();
            Int16 result;
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .TryParsInt16( out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}