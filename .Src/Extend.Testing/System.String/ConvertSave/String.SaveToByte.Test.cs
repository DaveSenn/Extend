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
        public void SaveToByteInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToByte();

            actual
                .Should()
                .Be( default(Byte) );
        }

        [Fact]
        public void SaveToByteInvalidValueWithDefaultValueTest()
        {
            const Byte expected = (Byte) 10;
            var actual = "InvalidValue".SaveToByte( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToByteNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToByte();

            actual
                .Should()
                .Be( default(Byte) );
        }

        [Fact]
        public void SaveToByteOverloadInvalidNumberFormatTest()
        {
            const Byte expected = (Byte) 10;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .SaveToByte( (NumberStyles) 1024, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SaveToByteOverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToByte( NumberStyles.AllowDecimalPoint,
                                                    CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Byte) );
        }

        [Fact]
        public void SaveToByteOverloadInvalidValueWithDefaultValueTest()
        {
            const Byte expected = (Byte) 10;
            var actual = "InvalidValue".SaveToByte( NumberStyles.AllowDecimalPoint,
                                                    CultureInfo.InvariantCulture,
                                                    expected );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToByteOverloadTest()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void SaveToByteOverloadTest1()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte( NumberStyles.Any, CultureInfo.InvariantCulture, 11 );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToByteTest()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte();

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void SaveToByteTestNullCheck1()
        {
            const Byte value = (Byte) 10;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToString()
                                     .SaveToByte( NumberStyles.AllowDecimalPoint, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SaveToByteWithDefaultValueTest()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte( 12 );

            actual
                .Should()
                .Be( expected );
        }
    }
}