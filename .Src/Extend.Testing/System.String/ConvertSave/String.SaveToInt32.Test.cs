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
        public void SaveToInt32InvalidValueDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt32( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt32InvalidValueTest()
        {
            var actual = "InvalidValue".SaveToInt32();

            actual
                .Should()
                .Be( default(Int32) );
        }

        [Test]
        public void SaveToInt32NullDefaultTest()
        {
            String value = null;
            var expected = RandomValueEx.GetRandomInt32();
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToInt32( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt32NullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToInt32();

            actual
                .Should()
                .Be( default(Int32) );
        }

        [Test]
        public void SaveToInt32OverloadFormatProviderNullTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "12".SaveToInt32( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SaveToInt32OverloadInvalidNumberStyleTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "12".SaveToInt32( NumberStyles.AllowDecimalPoint | NumberStyles.HexNumber, CultureInfo.CurrentCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void SaveToInt32OverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Int32) );
        }

        [Test]
        public void SaveToInt32OverloadInvalidValueWithDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt32OverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Int32) );
        }

        [Test]
        public void SaveToInt32OverloadNullWithDefaultTest()
        {
            String value = null;
            var expected = RandomValueEx.GetRandomInt32();
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt32OverloadTest()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt32OverloadWitDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture, RandomValueEx.GetRandomInt32() );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt32Test()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt32();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToInt32WithDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt32( RandomValueEx.GetRandomInt32() );

            actual
                .Should()
                .Be( expected );
        }
    }
}