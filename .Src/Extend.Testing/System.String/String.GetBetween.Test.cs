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
        public void GetBetweenArgumentOutOfRangeTestCase()
        {
            Action test = () => "121test2".GetBetween( "1", "2", 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenArgumentOutOfRangeTestCase1()
        {
            Action test = () => "1test2".GetBetween( "1", "2", 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenArgumentOutOfRangeTestCase2()
        {
            Action test = () => "121test2".GetBetween( "1", "2", 2, 60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenArgumentOutOfRangeTestCase3()
        {
            Action test = () => "121test2".GetBetween( "1", "2", -2, 60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenArgumentOutOfRangeTestCase4()
        {
            Action test = () => "121test2".GetBetween( "1", "2", 2, -60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenCharArgumentOutOfRangeTestCase()
        {
            Action test = () => "121test2".GetBetween( '1', '2', 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenCharArgumentOutOfRangeTestCase1()
        {
            Action test = () => "1test2".GetBetween( '1', '2', 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenCharArgumentOutOfRangeTestCase2()
        {
            Action test = () => "121test2".GetBetween( '1', '2', 2, 60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenCharArgumentOutOfRangeTestCase3()
        {
            Action test = () => "121test2".GetBetween( '1', '2', -2, 60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenCharArgumentOutOfRangeTestCase4()
        {
            Action test = () => "121test2".GetBetween( '1', '2', 2, -60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenCharTestCase()
        {
            var actual = "1test2".GetBetween( '1', '2' );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( '1', '2', 2 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        public void GetBetweenCharTestCase1()
        {
            var actual = "1test2".GetBetween( '1', '2', 0, 6 );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( '1', '2', 2, 6 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        public void GetBetweenCharTestCase1NullCheck()
        {
            Action test = () => StringEx.GetBetween( null, 't', 't' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenCharTestCase2()
        {
            var actual = "1test2".GetBetween( 'a', '2' );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBetweenCharTestCase3()
        {
            var actual = "1test2".GetBetween( 't', 'b' );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBetweenCharTestCaseNullCheck()
        {
            Action test = () => StringEx.GetBetween( null, 't', 't' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenTestCase()
        {
            var actual = "1test2".GetBetween( "1", "2" );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( "1", "2", 2 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        public void GetBetweenTestCase1()
        {
            var actual = "1test2".GetBetween( "1", "2", 0, 6 );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( "1", "2", 2, 6 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        public void GetBetweenTestCase1NullCheck()
        {
            Action test = () => StringEx.GetBetween( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenTestCase1NullCheck1()
        {
            Action test = () => "".GetBetween( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenTestCase1NullCheck2()
        {
            Action test = () => "".GetBetween( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenTestCase2()
        {
            var actual = "1test2".GetBetween( "1", "a" );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBetweenTestCase3()
        {
            var actual = "1test2".GetBetween( "a", "t" );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBetweenTestCaseNullCheck()
        {
            Action test = () => StringEx.GetBetween( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenTestCaseNullCheck1()
        {
            Action test = () => "".GetBetween( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenTestCaseNullCheck2()
        {
            Action test = () => "".GetBetween( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}