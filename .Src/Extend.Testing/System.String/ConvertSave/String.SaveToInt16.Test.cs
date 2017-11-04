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
        public void SaveToInt16InvalidValueDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = "InvalidValue".SaveToInt16( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToInt16InvalidValueTest()
        {
            var actual = "InvalidValue".SaveToInt16();

            actual
                .Should()
                .Be( default(Int16) );
        }

        [Fact]
        public void SaveToInt16NullDefaultTest()
        {
            String value = null;
            var expected = RandomValueEx.GetRandomInt16();
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToInt16( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToInt16NullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToInt16();

            actual
                .Should()
                .Be( default(Int16) );
        }

        [Fact]
        public void SaveToInt16OverloadFormatProviderNullTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "12".SaveToInt16( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SaveToInt16OverloadInvalidNumberStyleTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "12".SaveToInt16( NumberStyles.AllowDecimalPoint | NumberStyles.HexNumber, CultureInfo.CurrentCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SaveToInt16OverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToInt16( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Int16) );
        }

        [Fact]
        public void SaveToInt16OverloadInvalidValueWithDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = "InvalidValue".SaveToInt16( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToInt16OverloadNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToInt16( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Int16) );
        }

        [Fact]
        public void SaveToInt16OverloadNullWithDefaultTest()
        {
            String value = null;
            var expected = RandomValueEx.GetRandomInt16();
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToInt16( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToInt16OverloadTest()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt16( NumberStyles.Any, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToInt16OverloadWitDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt16( NumberStyles.Any, CultureInfo.InvariantCulture, RandomValueEx.GetRandomInt16() );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToInt16Test()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt16();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToInt16WithDefaultTest()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt16( RandomValueEx.GetRandomInt16() );

            actual
                .Should()
                .Be( expected );
        }
    }
}