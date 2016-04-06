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
        public void GetBetweenArgumentOutOfRangeTest()
        {
            Action test = () => "121test2".GetBetween( "1", "2", 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenArgumentOutOfRangeTest1()
        {
            Action test = () => "1test2".GetBetween( "1", "2", 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenArgumentOutOfRangeTest2()
        {
            Action test = () => "121test2".GetBetween( "1", "2", 2, 60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenArgumentOutOfRangeTest3()
        {
            Action test = () => "121test2".GetBetween( "1", "2", -2, 60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenArgumentOutOfRangeTest4()
        {
            Action test = () => "121test2".GetBetween( "1", "2", 2, -60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenCharArgumentOutOfRangeTest()
        {
            Action test = () => "121test2".GetBetween( '1', '2', 20 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenCharArgumentOutOfRangeTest1()
        {
            Action test = () => "1test2".GetBetween( '1', '2', 20, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenCharArgumentOutOfRangeTest2()
        {
            Action test = () => "121test2".GetBetween( '1', '2', 2, 60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenCharArgumentOutOfRangeTest3()
        {
            Action test = () => "121test2".GetBetween( '1', '2', -2, 60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenCharArgumentOutOfRangeTest4()
        {
            Action test = () => "121test2".GetBetween( '1', '2', 2, -60 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetBetweenCharTest()
        {
            var actual = "1test2".GetBetween( '1', '2' );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( '1', '2', 2 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        public void GetBetweenCharTest1()
        {
            var actual = "1test2".GetBetween( '1', '2', 0, 6 );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( '1', '2', 2, 6 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        public void GetBetweenCharTest1NullCheck()
        {
            Action test = () => StringEx.GetBetween( null, 't', 't' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenCharTest2()
        {
            var actual = "1test2".GetBetween( 'a', '2' );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBetweenCharTest3()
        {
            var actual = "1test2".GetBetween( 't', 'b' );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBetweenCharTestNullCheck()
        {
            Action test = () => StringEx.GetBetween( null, 't', 't' );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenTest()
        {
            var actual = "1test2".GetBetween( "1", "2" );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( "1", "2", 2 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        public void GetBetweenTest1()
        {
            var actual = "1test2".GetBetween( "1", "2", 0, 6 );
            Assert.AreEqual( "test", actual );

            actual = "121test2".GetBetween( "1", "2", 2, 6 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        public void GetBetweenTest1NullCheck()
        {
            Action test = () => StringEx.GetBetween( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenTest1NullCheck1()
        {
            Action test = () => "".GetBetween( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenTest1NullCheck2()
        {
            Action test = () => "".GetBetween( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenTest2()
        {
            var actual = "1test2".GetBetween( "1", "a" );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBetweenTest3()
        {
            var actual = "1test2".GetBetween( "a", "t" );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void GetBetweenTestNullCheck()
        {
            Action test = () => StringEx.GetBetween( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenTestNullCheck1()
        {
            Action test = () => "".GetBetween( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetBetweenTestNullCheck2()
        {
            Action test = () => "".GetBetween( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}