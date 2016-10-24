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
        public void ToDateTimeFormatProviderNullTest()
        {
            var expected = DateTime.Now;
            var value = expected.ToString( CultureInfo.CurrentCulture ) as Object;
            var actual = value.ToDateTime( null );

            actual
                .Should()
                .BeCloseTo( expected, 1000 );
        }

        [Test]
        public void ToDateTimeFormatProviderTest()
        {
            var expected = DateTime.Now;
            var value = expected.ToString( CultureInfo.CurrentCulture ) as Object;
            var actual = value.ToDateTime( CultureInfo.CurrentCulture );

            actual
                .Should()
                .BeCloseTo( expected, 1000 );
        }

        [Test]
        public void ToDateTimeInvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDateTime( CultureInfo.CurrentCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToDateTimeInvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToDateTime();
            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToDateTimeInvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToDateTime( value, CultureInfo.CurrentCulture );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToDateTimeInvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToDateTime( value );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToDateTimeNullValueFormatProviderTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToDateTime( CultureInfo.CurrentCulture );

            actual
                .Should()
                .Be( DateTime.MinValue );
        }

        [Test]
        public void ToDateTimeNullValueTest()
        {
            Object value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ToDateTime();

            actual
                .Should()
                .Be( DateTime.MinValue );
        }

        [Test]
        public void ToDateTimeTest()
        {
            var expected = DateTime.Now;
            var value = expected.ToString( CultureInfo.CurrentCulture ) as Object;
            var actual = value.ToDateTime();

            actual
                .Should()
                .BeCloseTo( expected, 1000 );
        }
    }
}