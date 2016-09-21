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
        public void ToByteInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".ToByte();

            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToByteNullTest()
        {
            String value = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToByte();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToByteOverflowTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "300".ToByte();

            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToByteTest()
        {
            const Byte value = (Byte) 1;
            var actual = value.ToString()
                              .ToByte();

            actual
                .Should()
                .Be( value );
        }

        [Test]
        public void ToByteWithFormatFormatNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "1".ToByte( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToByteWithFormatInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".ToByte( CultureInfo.InvariantCulture );

            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToByteWithFormatOverflowTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "300".ToByte( CultureInfo.InvariantCulture );

            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToByteWithFormatTest()
        {
            const Byte value = (Byte) 1;
            var actual = value.ToString()
                              .ToByte( CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( value );
        }

        [Test]
        public void ToByteWithFormatValueNullTest()
        {
            String value = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToByte( CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}