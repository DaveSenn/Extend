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
        public void GetAfteOverloadrArgumentOutOfRangeTestCase1()
        {
            Action test = () => "test test1".GetAfter( 't', 4, 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterArgumentOutOfRangeTestCase()
        {
            Action test = () => "test test1".GetAfter( "test", 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterArgumentOutOfRangeTestCase1()
        {
            Action test = () => "test test1".GetAfter( "test", 4, 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterArgumentOutOfRangeTestCase2()
        {
            Action test = () => "test test1".GetAfter( "test", 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterArgumentOutOfRangeTestCase3()
        {
            Action test = () => "test test1".GetAfter( "test", -1, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterArgumentOutOfRangeTestCase4()
        {
            Action test = () => "test test1".GetAfter( "test", 20, -2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterOverloadArgumentOutOfRangeTestCase()
        {
            Action test = () => "test test1".GetAfter( 't', 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterOverloadArgumentOutOfRangeTestCase2()
        {
            Action test = () => "test test1".GetAfter( 't', 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterOverloadTestCase()
        {
            var actual = "test test1".GetAfter( 's' );
            Assert.AreEqual( "t test1", actual );

            actual = "test test1".GetAfter( "t", 5 );
            Assert.AreEqual( "est1", actual );
        }

        [Test]
        public void GetAfterOverloadTestCase1()
        {
            var actual = "test test1".GetAfter( 'e', 0, 6 );
            Assert.AreEqual( "st t", actual );

            actual = "test test1".GetAfter( 't', 2, 8 );
            Assert.AreEqual( " test1", actual );
        }

        [Test]
        public void GetAfterOverloadTestCase1NullCheck()
        {
            Action test = () => StringEx.GetAfter( null, 't', 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetAfterOverloadTestCase2()
        {
            var actual = "test test1".GetAfter( 'a' );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetAfterOverloadTestCaseNullCheck()
        {
            Action test = () => StringEx.GetAfter( null, 't' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetAfterTestCase()
        {
            var actual = "test test1".GetAfter( "test" );
            Assert.AreEqual( " test1", actual );

            actual = "test test1".GetAfter( "test", 2 );
            Assert.AreEqual( "1", actual );
        }

        [Test]
        public void GetAfterTestCase1()
        {
            var actual = "test test1".GetAfter( "test", 0, 10 );
            Assert.AreEqual( " test1", actual );

            actual = "test test1".GetAfter( "test", 2, 8 );
            Assert.AreEqual( "1", actual );
        }

        [Test]
        public void GetAfterTestCase1NullCheck()
        {
            Action test = () => StringEx.GetAfter( null, "", 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetAfterTestCase1NullCheck1()
        {
            Action test = () => "".GetAfter( null, 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetAfterTestCase2()
        {
            var actual = "test123456789".GetAfter( "a", 0, 10 );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetAfterTestCaseNullCheck()
        {
            Action test = () => StringEx.GetAfter( null, "test" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetAfterTestCaseNullCheck1()
        {
            Action test = () => "".GetAfter( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}