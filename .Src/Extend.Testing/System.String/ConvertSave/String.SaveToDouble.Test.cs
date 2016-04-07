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

        [Test]
        public void SaveToDoubleInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToDouble();

            actual
                .Should()
                .Be( default(Double) );
        }

        [Test]
        public void SaveToDoubleInvalidValueWithDefaultTest()
        {
            const Double expected = 123.12334d;
            var actual = "InvalidValue".SaveToDouble( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToDoubleOverloadFormatProviderNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "123.2".SaveToDouble( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SaveToDoubleOverloadInvalidNumberStyleTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "123.2".SaveToDouble( NumberStyles.AllowHexSpecifier, CultureInfo.CurrentCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void SaveToDoubleOverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToDouble( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Double) );
        }

        [Test]
        public void SaveToDoubleOverloadInvalidValueWithDefaultTest()
        {
            const Double expected = 12345234.1321d;
            var actual = "InvalidValue".SaveToDouble( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToDoubleOverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToDouble( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Double) );
        }

        [Test]
        public void SaveToDoubleOverloadTest()
        {
            const Double expected = 12345234.1321d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDouble( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToDoubleTest()
        {
            const Double expected = 100.1d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDouble();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
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