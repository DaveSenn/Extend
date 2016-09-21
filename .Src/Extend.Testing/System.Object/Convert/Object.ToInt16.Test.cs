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
        public void ToInt16FormatProviderNullTest()
        {
            const Int16 expected = 666;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToInt16( null );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToInt16FormatProviderTest()
        {
            const Int16 expected = 666;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToInt16( CultureInfo.CurrentCulture );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToInt16InvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16( CultureInfo.CurrentCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToInt16InvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16();
            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToInt16InvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToInt16( value, CultureInfo.CurrentCulture );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToInt16InvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToInt16( value );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToInt16NullValueFormatProviderTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToInt16( CultureInfo.CurrentCulture );

            actual
                .Should()
                .Be( 0 );
        }

        [Test]
        public void ToInt16NullValueTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToInt16();

            actual
                .Should()
                .Be( 0 );
        }

        [Test]
        public void ToInt16Test()
        {
            const Int16 expected = 666;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToInt16();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToInt16TooLargeFormatProviderTest()
        {
            var value = Int16.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16( CultureInfo.CurrentCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToInt16TooLargeTest()
        {
            var value = Int16.MaxValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16();
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToInt16TooSmallFormatProviderTest()
        {
            var value = Int16.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16( CultureInfo.CurrentCulture );
            test.ShouldThrow<OverflowException>();
        }

        [Test]
        public void ToInt16TooSmallTest()
        {
            var value = Int16.MinValue.ToString( CultureInfo.InvariantCulture ) + "1";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToInt16();
            test.ShouldThrow<OverflowException>();
        }
    }
}