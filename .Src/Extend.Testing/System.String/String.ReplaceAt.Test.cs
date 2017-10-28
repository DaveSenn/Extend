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
        public void ReplaceAtArgumentNullExceptionTest()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.ReplaceAt( 4, '1' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ReplaceAtArgumentOutOfRangeExceptionTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".ReplaceAt( -1, '1' );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ReplaceAtArgumentOutOfRangeExceptionTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".ReplaceAt( 4, '1' );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ReplaceAtTest()
        {
            var actual = "test".ReplaceAt( 1, 'X' );

            actual.Should()
                  .Be( "tXst" );
        }

        [Fact]
        public void ReplaceAtTest1()
        {
            var actual = "test".ReplaceAt( 0, 'T' );

            actual.Should()
                  .Be( "Test" );
        }

        [Fact]
        public void ReplaceAtTest2()
        {
            var actual = "test".ReplaceAt( 3, '1' );

            actual.Should()
                  .Be( "tes1" );
        }
    }
}