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
        public void SaveToByteInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToByte();

            actual
                .Should()
                .Be( default(Byte) );
        }

        [Test]
        public void SaveToByteInvalidValueWithDefaultValueTest()
        {
            const Byte expected = (Byte) 10;
            var actual = "InvalidValue".SaveToByte( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToByteNullTest()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToByte();

            actual
                .Should()
                .Be( default(Byte) );
        }

        [Test]
        public void SaveToByteOverloadInvalidNumberFormatTest()
        {
            const Byte expected = (Byte) 10;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => expected.ToString( CultureInfo.InvariantCulture )
                                        .SaveToByte( (NumberStyles) 1024, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void SaveToByteOverloadInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToByte( NumberStyles.AllowDecimalPoint,
                                                    CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( default(Byte) );
        }

        [Test]
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

        [Test]
        public void SaveToByteOverloadTest()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteOverloadTest1()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte( NumberStyles.Any, CultureInfo.InvariantCulture, 11 );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToByteTest()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToByteTestNullCheck1()
        {
            const Byte value = (Byte) 10;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToString()
                                     .SaveToByte( NumberStyles.AllowDecimalPoint, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SaveToByteWithDefaultValueTest()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte( Byte.MinValue );

            actual
                .Should()
                .Be( expected );
        }
    }
}