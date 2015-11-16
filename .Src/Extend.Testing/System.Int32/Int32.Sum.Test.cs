#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void SumTestCase()
        {
            var actual = 10.Sum( 20, 30, 40, 50 );
            Assert.AreEqual( 150, actual );
        }

        [Test]
        public void SumTestCase1()
        {
            var actual = ( 10 as Int32? ).Sum( 20, null, 40, null );
            Assert.AreEqual( 70, actual );

            actual = ( null as Int32? ).Sum( new Int32?[]
            {
                null,
                null
            } );
            Assert.AreEqual( 0, actual );
        }

        [Test]
        public void SumTestCase1NullCheck()
        {
            Int32?[] values = null;
            Action test = () => ( 10 as Int32? ).Sum( values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTestCase2()
        {
            var actual = "test".Sum( x => x.Length, "a", "b", "c", "d" );
            Assert.AreEqual( 8, actual );

            actual = "".Sum( x => x.Length, "a", "b", "c", "d" );
            Assert.AreEqual( 4, actual );
        }

        [Test]
        public void SumTestCase2NullCheck()
        {
            String[] values = null;
            Action test = () => "Test".Sum( x => x.Length, values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTestCase2NullCheck2()
        {
            Func<String, Int32> func = null;
            Action test = () => "Test".Sum( func, "test", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTestCase3()
        {
            var actual = "test".Sum( x => x.Length > 1 ? (Int32?) x.Length : null, "a", "b", "c", "d" );
            Assert.AreEqual( 4, actual );

            actual = "test".Sum( x => x.Length > 1 ? (Int32?) x.Length : null, "aaaa", "b", "c", "d" );
            Assert.AreEqual( 8, actual );
        }

        [Test]
        public void SumTestCase3NullCheck()
        {
            String[] values = null;
            Action test = () => "Test".Sum( x => (Int32?) x.Length, values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTestCase3NullCheck2()
        {
            Func<String, Int32?> func = null;
            Action test = () => "Test".Sum( func, "test", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SumTestCaseNullCheck()
        {
            Int32[] values = null;
            Action test = () => 10.Sum( values );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}