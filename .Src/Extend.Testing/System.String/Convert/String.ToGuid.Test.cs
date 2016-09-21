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
        public void ToGuidInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "InvalidFormat".ToGuid();

            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToGuidNullTest()
        {
            String value = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ToGuid();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToGuidTest()
        {
            var value = Guid.NewGuid();
            var actual = value.ToString()
                              .ToGuid();

            actual
                .Should()
                .Be( value );
        }
    }
}