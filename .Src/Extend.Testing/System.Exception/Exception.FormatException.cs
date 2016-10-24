#region Usings

using System;
using System.Security;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class ExceptionExTest
    {
        [Test]
        public void FormatExceptionInnerExceptionTest()
        {
            var exception = new Exception( "some exception message", new SecurityException( "inner exception" ) );
            var actual = exception.FormatException( x =>
                                                    {
                                                        x.AppendLine( "A new line" );
                                                        x.AppendLine( "Another line" );
                                                    } );

            actual.Should()
                  .Be(
                      "Exception: some exception message\r\nA new line\r\nAnother line\r\n\r\n ---> System.Security.SecurityException: inner exception\r\nThe Zone of the assembly that failed was:\r\nMyComputer\r\n   --- End of inner exception stack trace ---\r\n" );
        }

        [Test]
        public void FormatExceptionNoActionTest()
        {
            var exception = new InvalidOperationException( "some exception message" );
            var actual = exception.FormatException();

            actual.Should()
                  .Be( "InvalidOperationException: some exception message\r\n" );
        }

        [Test]
        public void FormatExceptionNullTest()
        {
            Exception exception = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => exception.FormatException();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void FormatExceptionTest()
        {
            var exception = new InvalidOperationException( "some exception message" );
            var actual = exception.FormatException( x => x.AppendLine( "A new line" ) );

            actual.Should()
                  .Be( "InvalidOperationException: some exception message\r\nA new line\r\n" );
        }
    }
}