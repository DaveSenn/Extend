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
        public void ToBooleanFormatNullTest()
        {
            var actual = "true".ToBoolean( null );
            actual
                .Should()
                .Be( true );
        }

        [Fact]
        public void ToBooleanInvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToBoolean( CultureInfo.CurrentCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToBooleanInvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToBoolean();
            test.ShouldThrow<InvalidCastException>();
        }

        [Fact]
        public void ToBooleanInvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToBoolean( CultureInfo.CurrentCulture );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToBooleanInvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToBoolean( value );
            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToBooleanTest()
        {
            var value = "false";
            var actual = ObjectEx.ToBoolean( value );
            actual
                .Should()
                .BeFalse();

            value = "true";
            actual = ObjectEx.ToBoolean( value );
            actual
                .Should()
                .BeTrue();
        }

        [Fact]
        public void ToBooleanTest1()
        {
            var value = "false";
            var actual = value.ToBoolean( CultureInfo.InvariantCulture );
            actual
                .Should()
                .BeFalse();

            value = "true";
            actual = value.ToBoolean( CultureInfo.InvariantCulture );
            actual
                .Should()
                .BeTrue();
        }

        [Fact]
        public void ToBooleanValueNullTest()
        {
            var actual = ObjectEx.ToBoolean( null, CultureInfo.InvariantCulture );
            actual
                .Should()
                .Be( false );
        }
    }
}