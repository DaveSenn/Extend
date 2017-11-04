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
        public void LeftArgumentNullExceptionTest()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.Left( 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void LeftArgumentOutOfRangeExceptionTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".Left( -1 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void LeftArgumentOutOfRangeExceptionTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".Left( 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void LeftTest()
        {
            var actual = "This is a test".Left( 6 );

            actual.Should()
                  .Be( "This i" );
        }

        [Fact]
        public void LeftTest1()
        {
            var actual = "".Left( 0 );

            actual.Should()
                  .Be( String.Empty );
        }

        [Fact]
        public void LeftTest2()
        {
            var actual = "This is a test".Left( 0 );

            actual.Should()
                  .Be( "" );
        }

        [Fact]
        public void LeftTest3()
        {
            var actual = "this is a test".Left( 2 );

            actual.Should()
                  .Be( "th" );
        }
    }
}