#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void ToCharInvalidLengthTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "aa".ToChar();

            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToCharInvalidLengthTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => String.Empty.ToChar();

            test.ShouldThrow<FormatException>();
        }

        [Fact]
        public void ToCharNullTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.ToChar( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToCharTest()
        {
            var actual = "a".ToChar();
            actual
                .Should()
                .Be( 'a' );
        }
    }
}