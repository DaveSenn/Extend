#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void ToCharFormatProviderNullTest()
        {
            const Char expected = 'a';
            var value = expected.ToString();
            var actual = value.ToChar( null );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToCharInvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToChar( CultureInfo.CurrentCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToCharInvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToChar();
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToCharInvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToChar( CultureInfo.CurrentCulture );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToCharInvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToChar( value );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToCharNullValueFormatProviderTest()
        {
            Object value = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToChar( CultureInfo.CurrentCulture );

            actual
                .Should()
                .Be( (Char) 0 );
        }

        [Fact]
        public void ToCharNullValueTest()
        {
            Object value = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToChar();

            actual
                .Should()
                .Be( (Char) 0 );
        }

        [Fact]
        public void ToCharTest()
        {
            const Char expected = 'a';
            var value = expected.ToString();
            var actual = ObjectEx.ToChar( value );

            actual
                .Should()
                .Be( expected );
        }

        [Fact]
        public void ToCharTooLargeFormatProviderTest()
        {
            const Int32 value = (Int32) Char.MaxValue + 1;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToChar( CultureInfo.CurrentCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToCharTooLargeTest()
        {
            const Int32 value = (Int32) Char.MaxValue + 1;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToChar();
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToCharTooSmallFormatProviderTest()
        {
            const Int32 value = (Int32) Char.MinValue - 1;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToChar( CultureInfo.CurrentCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Fact]
        public void ToCharTooSmallTest()
        {
            const Int32 value = (Int32) Char.MinValue - 1;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToChar();
            test.ShouldThrow<OverflowException>();
        }
    }
}