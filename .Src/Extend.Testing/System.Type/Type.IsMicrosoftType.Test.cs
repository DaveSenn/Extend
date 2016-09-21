#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class TypeExTest
    {
        [Test]
        public void IsMicrosoftTypeNullTest()
        {
            Type type = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => type.IsMicrosoftType();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsMicrosoftTypeTest()
        {
            var type = typeof(String);
            var actual = type.IsMicrosoftType();

            Assert.IsTrue( actual );
        }

        [Test]
        public void IsMicrosoftTypeTest1()
        {
            var type = typeof(TypeExTest);
            var actual = type.IsMicrosoftType();

            Assert.IsFalse( actual );
        }
    }
}