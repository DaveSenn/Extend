#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class TypeExTest
    {
        [Fact]
        public void IsMicrosoftTypeNullTest()
        {
            Type type = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => type.IsMicrosoftType();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsMicrosoftTypeTest()
        {
            var type = typeof(String);
            var actual = type.IsMicrosoftType();

            Assert.True( actual );
        }

        [Fact]
        public void IsMicrosoftTypeTest1()
        {
            var type = typeof(TypeExTest);
            var actual = type.IsMicrosoftType();

            Assert.False( actual );
        }
    }
}