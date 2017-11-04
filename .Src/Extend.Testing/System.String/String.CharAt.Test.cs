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
        public void CharAtArgumentNullExceptionTest()
        {
            String value = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.CharAt( 1 );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CharAtArgumentOutOfRangeExceptionTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".CharAt( 0 );
            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CharAtArgumentOutOfRangeExceptionTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".CharAt( -1 );
            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CharAtArgumentOutOfRangeExceptionTest2()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".CharAt( 4 );
            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CharAtTest()
        {
            var actual = "test".CharAt( 0 );

            actual.Should()
                  .Be( 't' );
        }

        [Fact]
        public void CharAtTest1()
        {
            var actual = "bar".CharAt( 1 );

            actual.Should()
                  .Be( 'a' );
        }

        [Fact]
        public void CharAtTest2()
        {
            var actual = "bar".CharAt( 2 );

            actual.Should()
                  .Be( 'r' );
        }
    }
}