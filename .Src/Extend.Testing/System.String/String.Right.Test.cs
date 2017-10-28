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
        public void RightArgumentNullExceptionTest()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.Right( 0 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RightArgumentOutOfRangeExceptionTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".Right( -1 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void RightArgumentOutOfRangeExceptionTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".Right( 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void RightTest()
        {
            var actual = "this".Right( 0 );

            actual.Should()
                  .Be( String.Empty );
        }

        [Fact]
        public void RightTest1()
        {
            var actual = "this".Right( 1 );

            actual.Should()
                  .Be( "s" );
        }

        [Fact]
        public void RightTest2()
        {
            var actual = "this".Right( 2 );

            actual.Should()
                  .Be( "is" );
        }

        [Fact]
        public void RightTest3()
        {
            var actual = "".Right( 0 );

            actual.Should()
                  .Be( String.Empty );
        }
    }
}