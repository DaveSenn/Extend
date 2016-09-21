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
        public void ToCharInvalidLengthTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "aa".ToChar();

            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToCharInvalidLengthTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => String.Empty.ToChar();

            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToCharNullTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.ToChar( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToCharTest()
        {
            var actual = "a".ToChar();
            actual
                .Should()
                .Be( 'a' );
        }
    }
}