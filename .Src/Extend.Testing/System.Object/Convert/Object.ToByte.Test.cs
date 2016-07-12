#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToByteFormatProviderNullTest()
        {
            const Byte expected = 1;
            var value = expected.ToString();
            var actual = ObjectEx.ToByte( value, null );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToByteFormatProviderTest()
        {
            const Byte expected = 1;
            var value = expected.ToString();
            var actual = ObjectEx.ToByte( value, CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToByteInvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToByte( CultureInfo.CurrentCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToByteInvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToByte();
            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToByteInvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToByte( value, CultureInfo.CurrentCulture );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToByteInvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToByte( value );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToByteNullValueFormatProviderTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToByte( CultureInfo.CurrentCulture );

            actual
                .Should()
                .Be( 0 );
        }

        [Test]
        public void ToByteNullValueTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToByte();

            actual
                .Should()
                .Be( 0 );
        }

        [Test]
        public void ToByteTest()
        {
            const Byte expected = 1;
            var value = expected.ToString();
            var actual = ObjectEx.ToByte( value );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToByteTooLargeFormatProviderTest()
        {
            const Int32 value = (Int32) Byte.MaxValue + 1;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToByte( CultureInfo.CurrentCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToByteTooLargeTest()
        {
            const Int32 value = (Int32) Byte.MaxValue + 1;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToByte();
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToByteTooSmallFormatProviderTest()
        {
            const Int32 value = (Int32) Byte.MinValue - 1;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToByte( CultureInfo.CurrentCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToByteTooSmallTest()
        {
            const Int32 value = (Int32) Byte.MinValue - 1;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToByte();
            test.ShouldThrow<OverflowException>();
        }
    }
}