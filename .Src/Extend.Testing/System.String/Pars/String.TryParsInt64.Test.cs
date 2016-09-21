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
        public void TryParsInt64InvalidValueTest()
        {
            Int64 result;
            var actual = "InvalidValue".TryParsInt64( out result );

            result
                .Should()
                .Be( default(Int64) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsInt64NullTest()
        {
            Int64 result;
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsInt64( out result );

            result
                .Should()
                .Be( default(Int64) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsInt64OverloadFormatProviderNullTest()
        {
            var expected = RandomValueEx.GetRandomInt64();
            CultureInfo culture = null;
            Int64 result;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .TryParsInt64( NumberStyles.Any, culture, out result );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsInt64OverloadInvalidNumberFormatTest()
        {
            Int64 result;
            var expected = RandomValueEx.GetRandomInt64();

            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .TryParsInt64( NumberStyles.AllowDecimalPoint | NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void TryParsInt64OverloadInvalidValueTest()
        {
            Int64 result;
            var actual = "InvalidValue".TryParsInt64( NumberStyles.Any, new CultureInfo( "de-CH" ), out result );

            result
                .Should()
                .Be( default(Int64) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsInt64OverloadNullTest()
        {
            Int64 result;
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsInt64( NumberStyles.Any, new CultureInfo( "de-CH" ), out result );

            result
                .Should()
                .Be( default(Int64) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsInt64OverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            var expected = RandomValueEx.GetRandomInt64();
            Int64 result;
            var actual = expected.ToString( culture )
                                 .TryParsInt64( NumberStyles.Any, culture, out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Test]
        public void TryParsInt64Test()
        {
            var expected = RandomValueEx.GetRandomInt64();
            Int64 result;
            var actual = expected.ToString( CultureInfo.CurrentCulture )
                                 .TryParsInt64( out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}