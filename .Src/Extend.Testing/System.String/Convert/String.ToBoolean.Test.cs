#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ToBooleanInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "invalidValue".ToBoolean();

            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToBooleanNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ToBoolean( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToBooleanTest()
        {
            var value = RandomValueEx.GetRandomBoolean();
            var actual = value.ToString()
                              .ToBoolean();

            actual
                .Should()
                .Be( value );
        }
    }
}