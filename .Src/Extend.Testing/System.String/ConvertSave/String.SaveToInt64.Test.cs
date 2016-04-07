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
        public void SaveToInt64InvalidValueDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = "InvalidValue".SaveToInt64( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt64InvalidValueTest()
        {
            var actual = "InvalidValue".SaveToInt64();

            actual
                .Should()
                .Be( default(Int64) );
        }

        [Test]
        public void SaveToInt64NullDefaultTest()
        {
            String value = null;
            var expected = RandomValueEx.GetRandomInt64();
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToInt64( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt64NullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToInt64();

            actual
                .Should()
                .Be( default(Int64) );
        }

        [Test]
        public void SaveToInt64OverloadFormatProviderNullTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "12".SaveToInt64( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SaveToInt64OverloadInvalidNumberStyleTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "12".SaveToInt64( NumberStyles.AllowDecimalPoint | NumberStyles.HexNumber, CultureInfo.CurrentCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void SaveToInt64OverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Int64) );
        }

        [Test]
        public void SaveToInt64OverloadInvalidValueWithDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = "InvalidValue".SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt64OverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Int64) );
        }

        [Test]
        public void SaveToInt64OverloadNullWithDefaultTest()
        {
            String value = null;
            var expected = RandomValueEx.GetRandomInt64();
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt64OverloadTest()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt64OverloadWitDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture, RandomValueEx.GetRandomInt64() );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt64Test()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt64();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt64WithDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt64( RandomValueEx.GetRandomInt64() );

            actual
                .Should()
                .Be( expected );
        }
    }
}