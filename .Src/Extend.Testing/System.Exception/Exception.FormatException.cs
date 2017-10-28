#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class ExceptionExTest
    {
        [Fact]
        public void FormatExceptionInnerExceptionTest()
        {
            var exception = new Exception( "some exception message", new InvalidOperationException( "inner exception" ) );
            var actual = exception.FormatException( x =>
            {
                x.AppendLine( "A new line" );
                x.AppendLine( "Another line" );
            } );

            actual.Should()
                  .Be( "Exception: some exception message\r\nA new line\r\nAnother line\r\n\r\n ---> System.InvalidOperationException: inner exception\r\n   --- End of inner exception stack trace ---\r\n" );
        }

        [Fact]
        public void FormatExceptionNoActionTest()
        {
            var exception = new InvalidOperationException( "some exception message" );
            var actual = exception.FormatException();

            actual.Should()
                  .Be( "InvalidOperationException: some exception message\r\n" );
        }

        [Fact]
        public void FormatExceptionNullTest()
        {
            Exception exception = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => exception.FormatException();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FormatExceptionTest()
        {
            var exception = new InvalidOperationException( "some exception message" );
            var actual = exception.FormatException( x => x.AppendLine( "A new line" ) );

            actual.Should()
                  .Be( "InvalidOperationException: some exception message\r\nA new line\r\n" );
        }
    }
}