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
        public void LeftArgumentNullExceptionTest()
        {
            String value = null;
            Action test = () => value.Left( 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void LeftArgumentOutOfRangeExceptionTest()
        {
            Action test = () => "test".Left( -1 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void LeftArgumentOutOfRangeExceptionTest1()
        {
            Action test = () => "test".Left( 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void LeftTest()
        {
            var actual = "This is a test".Left( 6 );

            actual.Should()
                  .Be( "This i" );
        }

        [Test]
        public void LeftTest1()
        {
            var actual = "".Left( 0 );

            actual.Should()
                  .Be( String.Empty );
        }

        [Test]
        public void LeftTest2()
        {
            var actual = "This is a test".Left( 0 );

            actual.Should()
                  .Be( "" );
        }

        [Test]
        public void LeftTest3()
        {
            var actual = "this is a test".Left( 2 );

            actual.Should()
                  .Be( "th" );
        }
    }
}