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
        public void SafeToByteInvalidValueTest()
        {
            var actual = "InvalidValue".SafeToByte();

            actual
                .Should()
                .Be( default(Byte) );
        }

        [Fact]
        public void SafeToByteInvalidValueWithDefaultValueTest()
        {
            const Byte expected = (Byte) 10;
            var actual = "InvalidValue".SafeToByte( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToByteNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SafeToByte();

            actual
                .Should()
                .Be( default(Byte) );
        }

        [Fact]
        public void SafeToByteOverloadInvalidNumberFormatTest()
        {
            const Byte expected = (Byte) 10;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .SafeToByte( (NumberStyles) 1024, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SafeToByteOverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SafeToByte( NumberStyles.AllowDecimalPoint,
                                                    CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Byte) );
        }

        [Fact]
        public void SafeToByteOverloadInvalidValueWithDefaultValueTest()
        {
            const Byte expected = (Byte) 10;
            var actual = "InvalidValue".SafeToByte( NumberStyles.AllowDecimalPoint,
                                                    CultureInfo.InvariantCulture,
                                                    expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToByteOverloadTest()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToByte( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void SafeToByteOverloadTest1()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToByte( NumberStyles.Any, CultureInfo.InvariantCulture, 11 );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToByteTest()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToByte();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SafeToByteTestNullCheck1()
        {
            const Byte value = (Byte) 10;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToString()
                                     .SafeToByte( NumberStyles.AllowDecimalPoint, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SafeToByteWithDefaultValueTest()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SafeToByte( 12 );

            actual
                .Should()
                .Be( expected );
        }
    }
}