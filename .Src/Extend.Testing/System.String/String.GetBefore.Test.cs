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
        public void GetBeforeArgumentOutOfRangeTestCase1()
        {
            Action test = () => "test test1".GetBefore( "test1", 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeArgumentOutOfRangeTestCase2()
        {
            Action test = () => "test test test".GetBefore( "test", 2, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeArgumentOutOfRangeTestCase3()
        {
            Action test = () => "test test test".GetBefore( "test", -2, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeArgumentOutOfRangeTestCase4()
        {
            Action test = () => "test test test".GetBefore( "test", 2, -20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeArgumentOutOfRangExceptionTestCase()
        {
            Action test = () => "test test".GetBefore( "test", 15 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeCharArgumentOutOfRangeTestCase1()
        {
            Action test = () => "test test1".GetBefore( 't', 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeCharArgumentOutOfRangeTestCase2()
        {
            Action test = () => "test test test".GetBefore( 't', 2, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeCharArgumentOutOfRangeTestCase3()
        {
            Action test = () => "test test test".GetBefore( 't', -2, 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeCharArgumentOutOfRangeTestCase4()
        {
            Action test = () => "test test test".GetBefore( 't', 2, -20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeCharArgumentOutOfRangExceptionTestCase()
        {
            Action test = () => "test test".GetBefore( 't', 15 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBeforeCharTestCase()
        {
            var actual = "test test1".GetBefore( 's' );
            Assert.AreEqual( "te", actual );

            actual = "test test test".GetBefore( 's', 5 );
            Assert.AreEqual( "te", actual );
        }

        [Test]
        public void GetBeforeCharTestCase1()
        {
            var actual = "test test1".GetBefore( 'e', 0, 4 );
            Assert.AreEqual( "t", actual );

            actual = "test test test".GetBefore( 'e', 3, 5 );
            Assert.AreEqual( "t t", actual );
        }

        [Test]
        public void GetBeforeCharTestCase1NullCheck()
        {
            Action test = () => StringEx.GetBefore( null, 't', 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBeforeCharTestCase2()
        {
            var actual = "test test1".GetBefore( 'a' );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBeforeCharTestCaseNullCheck()
        {
            Action test = () => StringEx.GetBefore( null, 't' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBeforeTestCase()
        {
            var actual = "test test1".GetBefore( "test1" );
            Assert.AreEqual( "test ", actual );

            actual = "test test test".GetBefore( "test", 8 );
            Assert.AreEqual( "t ", actual );
        }

        [Test]
        public void GetBeforeTestCase1()
        {
            var actual = "test test1".GetBefore( "test1", 0, 10 );
            Assert.AreEqual( "test ", actual );

            actual = "test test test".GetBefore( "test", 8, 6 );
            Assert.AreEqual( "t ", actual );
        }

        [Test]
        public void GetBeforeTestCase1NullCheck()
        {
            Action test = () => StringEx.GetBefore( null, "", 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBeforeTestCase1NullCheck1()
        {
            Action test = () => "".GetBefore( null, 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBeforeTestCase2()
        {
            var actual = "test test1".GetBefore( "a", 0, 10 );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBeforeTestCaseNullCheck()
        {
            Action test = () => StringEx.GetBefore( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBeforeTestCaseNullCheck1()
        {
            Action test = () => "".GetBefore( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}