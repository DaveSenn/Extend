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
        public void RightArgumentNullExceptionTest()
        {
            String value = null;

            Action test = () => value.Right( 0 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void RightArgumentOutOfRangeExceptionTest()
        {
            Action test = () => "test".Right( -1 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void RightArgumentOutOfRangeExceptionTest1()
        {
            Action test = () => "test".Right( 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void RightTest()
        {
            var actual = "this".Right( 0 );

            actual.Should()
                  .Be( String.Empty );
        }

        [Test]
        public void RightTest1()
        {
            var actual = "this".Right( 1 );

            actual.Should()
                  .Be( "s" );
        }

        [Test]
        public void RightTest2()
        {
            var actual = "this".Right( 2 );

            actual.Should()
                  .Be( "is" );
        }

        [Test]
        public void RightTest3()
        {
            var actual = "".Right( 0 );

            actual.Should()
                  .Be( String.Empty );
        }
    }
}