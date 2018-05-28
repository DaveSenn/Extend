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
        public void ToByteInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".ToByte();

            Assert.Throws<FormatException>( test );
        }

        [Fact]
        public void ToByteNullTest()
        {
            String value = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToByte();

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ToByteOverflowTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "300".ToByte();

            Assert.Throws<OverflowException>( test );
        }

        [Fact]
        public void ToByteTest()
        {
            const Byte value = (Byte) 1;
            var actual = value.ToString()
                              .ToByte();

            actual
                .Should()
                .Be( value );
        }

        [Fact]
        public void ToByteWithFormatFormatNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "1".ToByte( null );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ToByteWithFormatInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".ToByte( CultureInfo.InvariantCulture );

            Assert.Throws<FormatException>( test );
        }

        [Fact]
        public void ToByteWithFormatOverflowTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "300".ToByte( CultureInfo.InvariantCulture );

            Assert.Throws<OverflowException>( test );
        }

        [Fact]
        public void ToByteWithFormatTest()
        {
            const Byte value = (Byte) 1;
            var actual = value.ToString()
                              .ToByte( CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( value );
        }

        [Fact]
        public void ToByteWithFormatValueNullTest()
        {
            String value = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToByte( CultureInfo.InvariantCulture );

            Assert.Throws<ArgumentNullException>( test );
        }
    }
}