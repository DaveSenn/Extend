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
        public void SafeToDoubleInvalidNullTest()
        {
            String value = null;
            const Double expected = 123.12334d;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToDouble( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDoubleInvalidValueTest()
        {
            var actual = "InvalidValue".SafeToDouble();

            actual
                .Should()
                .Be( default(Double) );
        }

        [Fact]
        public void SafeToDoubleInvalidValueWithDefaultTest()
        {
            const Double expected = 123.12334d;
            var actual = "InvalidValue".SafeToDouble( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDoubleOverloadFormatProviderNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "123.2".SafeToDouble( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SafeToDoubleOverloadInvalidNumberStyleTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "123.2".SafeToDouble( NumberStyles.AllowHexSpecifier, CultureInfo.CurrentCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SafeToDoubleOverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SafeToDouble( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Double) );
        }

        [Fact]
        public void SafeToDoubleOverloadInvalidValueWithDefaultTest()
        {
            const Double expected = 12345234.1321d;
            var actual = "InvalidValue".SafeToDouble( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDoubleOverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToDouble( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Double) );
        }

        [Fact]
        public void SafeToDoubleOverloadTest()
        {
            const Double expected = 12345234.1321d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToDouble( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDoubleTest()
        {
            const Double expected = 100.1d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToDouble();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToDoubleWithDefaultTest()
        {
            const Double expected = 100.1d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToDouble( Double.MinValue );

            actual
                .Should()
                .Be( expected );
        }
    }
}