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
        public void ToBooleanFormatNullTest()
        {
            var actual = "true".ToBoolean( null );
            actual
                .Should()
                .Be( true );
        }

        [Test]
        public void ToBooleanInvalidCastFormatProviderTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToBoolean( CultureInfo.CurrentCulture );
            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToBooleanInvalidCastTest()
        {
            var value = new TestModel();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToBoolean();
            test.ShouldThrow<InvalidCastException>();
        }

        [Test]
        public void ToBooleanInvalidFormatFormatProviderTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToBoolean( CultureInfo.CurrentCulture );
            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToBooleanInvalidFormatTest()
        {
            const String value = "invalidFormat";

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.ToBoolean( value );
            test.ShouldThrow<FormatException>();
        }

        [Test]
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

        [Test]
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

        [Test]
        public void ToBooleanValueNullTest()
        {
            var actual = ObjectEx.ToBoolean( null, CultureInfo.InvariantCulture );
            actual
                .Should()
                .Be( false );
        }
    }
}