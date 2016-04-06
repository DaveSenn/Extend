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
        public void GetBeforeArgumentOutOfRangeTest1()
        {
            Action test = () => "test test1".GetBefore( "test1", 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeArgumentOutOfRangeTest2()
        {
            Action test = () => "test test test".GetBefore( "test", 2, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeArgumentOutOfRangeTest3()
        {
            Action test = () => "test test test".GetBefore( "test", -2, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeArgumentOutOfRangeTest4()
        {
            Action test = () => "test test test".GetBefore( "test", 2, -20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeArgumentOutOfRangExceptionTest()
        {
            Action test = () => "test test".GetBefore( "test", 15 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeCharArgumentOutOfRangeTest1()
        {
            Action test = () => "test test1".GetBefore( 't', 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeCharArgumentOutOfRangeTest2()
        {
            Action test = () => "test test test".GetBefore( 't', 2, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeCharArgumentOutOfRangeTest3()
        {
            Action test = () => "test test test".GetBefore( 't', -2, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeCharArgumentOutOfRangeTest4()
        {
            Action test = () => "test test test".GetBefore( 't', 2, -20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeCharArgumentOutOfRangExceptionTest()
        {
            Action test = () => "test test".GetBefore( 't', 15 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeCharTest()
        {
            var actual = "test test1".GetBefore( 's' );
            Assert.AreEqual( "te", actual );

            actual = "test test test".GetBefore( 's', 5 );
            Assert.AreEqual( "te", actual );
        }

        [Test]
        public void GetBeforeCharTest1()
        {
            var actual = "test test1".GetBefore( 'e', 0, 4 );
            Assert.AreEqual( "t", actual );

            actual = "test test test".GetBefore( 'e', 3, 5 );
            Assert.AreEqual( "t t", actual );
        }

        [Test]
        public void GetBeforeCharTest1NullCheck()
        {
            Action test = () => StringEx.GetBefore( null, 't', 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBeforeCharTest2()
        {
            var actual = "test test1".GetBefore( 'a' );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBeforeCharTestNullCheck()
        {
            Action test = () => StringEx.GetBefore( null, 't' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBeforeTest()
        {
            var actual = "test test1".GetBefore( "test1" );
            Assert.AreEqual( "test ", actual );

            actual = "test test test".GetBefore( "test", 8 );
            Assert.AreEqual( "t ", actual );
        }

        [Test]
        public void GetBeforeTest1()
        {
            var actual = "test test1".GetBefore( "test1", 0, 10 );
            Assert.AreEqual( "test ", actual );

            actual = "test test test".GetBefore( "test", 8, 6 );
            Assert.AreEqual( "t ", actual );
        }

        [Test]
        public void GetBeforeTest1NullCheck()
        {
            Action test = () => StringEx.GetBefore( null, "", 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBeforeTest1NullCheck1()
        {
            Action test = () => "".GetBefore( null, 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBeforeTest2()
        {
            var actual = "test test1".GetBefore( "a", 0, 10 );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBeforeTestNullCheck()
        {
            Action test = () => StringEx.GetBefore( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBeforeTestNullCheck1()
        {
            Action test = () => "".GetBefore( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}