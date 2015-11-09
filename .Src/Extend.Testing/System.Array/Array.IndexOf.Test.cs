#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void IndexOfTestCase()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var actual = array.IndexOf( "1" );

            Assert.AreEqual( 1, actual );
        }

        [Test]
        public void IndexOfTestCase1()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var actual = array.IndexOf( "1", 2 );

            Assert.AreEqual( -1, actual );
        }

        [Test]
        public void IndexOfTestCase1NullCheck()
        {
            Array array = null;
            Action test = () => array.IndexOf( "test", 10 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IndexOfTestCase2()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };

            var actual = array.IndexOf( "1", 0, 2 );
            Assert.AreEqual( 1, actual );

            actual = array.IndexOf( "2", 0, 2 );
            Assert.AreEqual( -1, actual );
        }

        [Test]
        public void IndexOfTestCase2NullCheck()
        {
            Array array = null;
            Action test = () => array.IndexOf( "test", 10, 12 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IndexOfTestCaseNullCheck()
        {
            Array array = null;
            Action test = () => array.IndexOf( "test" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}