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
        public void GetAfteOverloadrArgumentOutOfRangeTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( 't', 4, 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterArgumentOutOfRangeTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( "test", 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterArgumentOutOfRangeTest1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( "test", 4, 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterArgumentOutOfRangeTest2()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( "test", 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterArgumentOutOfRangeTest3()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( "test", -1, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterArgumentOutOfRangeTest4()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( "test", 20, -2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterOverloadArgumentOutOfRangeTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( 't', 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterOverloadArgumentOutOfRangeTest2()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test test1".GetAfter( 't', 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetAfterOverloadTest()
        {
            var actual = "test test1".GetAfter( 's' );
            Assert.AreEqual( "t test1", actual );

            actual = "test test1".GetAfter( "t", 5 );
            Assert.AreEqual( "est1", actual );
        }

        [Test]
        public void GetAfterOverloadTest1()
        {
            var actual = "test test1".GetAfter( 'e', 0, 6 );
            Assert.AreEqual( "st t", actual );

            actual = "test test1".GetAfter( 't', 2, 8 );
            Assert.AreEqual( " test1", actual );
        }

        [Test]
        public void GetAfterOverloadTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetAfter( null, 't', 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetAfterOverloadTest2()
        {
            var actual = "test test1".GetAfter( 'a' );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetAfterOverloadTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetAfter( null, 't' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetAfterTest()
        {
            var actual = "test test1".GetAfter( "test" );
            Assert.AreEqual( " test1", actual );

            actual = "test test1".GetAfter( "test", 2 );
            Assert.AreEqual( "1", actual );
        }

        [Test]
        public void GetAfterTest1()
        {
            var actual = "test test1".GetAfter( "test", 0, 10 );
            Assert.AreEqual( " test1", actual );

            actual = "test test1".GetAfter( "test", 2, 8 );
            Assert.AreEqual( "1", actual );
        }

        [Test]
        public void GetAfterTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetAfter( null, "", 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetAfterTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetAfter( null, 1, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetAfterTest2()
        {
            var actual = "test123456789".GetAfter( "a", 0, 10 );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetAfterTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetAfter( null, "test" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetAfterTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".GetAfter( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}