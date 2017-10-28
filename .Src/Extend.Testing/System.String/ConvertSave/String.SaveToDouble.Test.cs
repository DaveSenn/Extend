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
        public void SaveToDoubleInvalidNullTest()
        {
            String value = null;
            const Double expected = 123.12334d;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToDouble( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToDoubleInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToDouble();

            actual
                .Should()
                .Be( default(Double) );
        }

        [Fact]
        public void SaveToDoubleInvalidValueWithDefaultTest()
        {
            const Double expected = 123.12334d;
            var actual = "InvalidValue".SaveToDouble( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToDoubleOverloadFormatProviderNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "123.2".SaveToDouble( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SaveToDoubleOverloadInvalidNumberStyleTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "123.2".SaveToDouble( NumberStyles.AllowHexSpecifier, CultureInfo.CurrentCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SaveToDoubleOverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToDouble( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Double) );
        }

        [Fact]
        public void SaveToDoubleOverloadInvalidValueWithDefaultTest()
        {
            const Double expected = 12345234.1321d;
            var actual = "InvalidValue".SaveToDouble( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToDoubleOverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToDouble( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Double) );
        }

        [Fact]
        public void SaveToDoubleOverloadTest()
        {
            const Double expected = 12345234.1321d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDouble( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToDoubleTest()
        {
            const Double expected = 100.1d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDouble();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToDoubleWithDefaultTest()
        {
            const Double expected = 100.1d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDouble( Double.MinValue );

            actual
                .Should()
                .Be( expected );
        }
    }
}