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
        public void SaveToDecimalFormatProviderNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new Decimal( 1 ).ToString( CultureInfo.InvariantCulture )
                                                .SaveToDouble( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SaveToDecimalInvalidNumberStyleTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new Decimal( 1 ).ToString( CultureInfo.InvariantCulture )
                                                .SaveToDouble( NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void SaveToDecimalInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToDecimal();

            actual
                .Should()
                .Be( default(Decimal) );
        }

        [Test]
        public void SaveToDecimalInvalidValueWithDefaultTest()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            var actual = "InvalidValue".SaveToDecimal( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToDecimalNullTest()
        {
            String value = null;
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToDecimal( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToDecimalOverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToDecimal( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Decimal) );
        }

        [Test]
        public void SaveToDecimalOverloadInvalidValueWithDefaultTest()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            var actual = "InvalidValue".SaveToDecimal( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToDecimalOverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToDecimal( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Decimal) );
        }

        [Test]
        public void SaveToDecimalOverloadTest()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDecimal( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToDecimalOverloadWithDefaultTest()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() + 0.1523 );
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDecimal( NumberStyles.Any, CultureInfo.InvariantCulture, Decimal.MinValue );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToDecimalTest()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDecimal();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToDecimalWithDefaultTest()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() + 0.123 );
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDecimal( Decimal.MaxValue );

            actual
                .Should()
                .Be( expected );
        }
    }
}