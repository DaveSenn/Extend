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
        public void ToDoubleFormatProviderNullTest()
        {
            const Double expected = 100.12;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDouble( null );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToDoubleFormatProviderTest()
        {
            const Double expected = 100.12;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDouble( CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToDoubleInvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDouble( CultureInfo.InvariantCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToDoubleInvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDouble();
            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToDoubleInvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToDouble( value, CultureInfo.InvariantCulture );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToDoubleInvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToDouble( value );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToDoubleNullValueFormatProviderTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToDouble( CultureInfo.InvariantCulture );

            actual
                .Should()
                .Be( 0 );
        }

        [Test]
        public void ToDoubleNullValueTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToDouble();

            actual
                .Should()
                .Be( 0 );
        }

        [Test]
        public void ToDoubleTest()
        {
            const Double expected = 100.12;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDouble();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToDoubleTooLargeFormatProviderTest()
        {
            var value = Double.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDouble( CultureInfo.InvariantCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToDoubleTooLargeTest()
        {
            var value = Double.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDouble();
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToDoubleTooSmallFormatProviderTest()
        {
            var value = Double.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDouble( CultureInfo.InvariantCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToDoubleTooSmallTest()
        {
            var value = Double.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDouble();
            test.ShouldThrow<OverflowException>();
        }
    }
}