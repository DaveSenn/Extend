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
        public void LastIndexOfTestCase()
        {
            Array array = new[]
            {
                "test",
                "test2",
                "test2"
            };
            var actual = array.LastIndexOf( "test2" );
            Assert.AreEqual( 2, actual );
        }

        [Test]
        public void LastIndexOfTestCase1()
        {
            Array array = new[]
            {
                "test",
                "test2",
                "test2"
            };
            var actual = array.LastIndexOf( "test2", 2 );
            Assert.AreEqual( 2, actual );
        }

        [Test]
        public void LastIndexOfTestCase1NullCheck()
        {
            Array array = null;
            Action test = () => array.LastIndexOf( "test2", 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void LastIndexOfTestCase2()
        {
            Array array = new[]
            {
                "test",
                "test2",
                "test2"
            };
            var actual = array.LastIndexOf( "test2", 1, 2 );
            Assert.AreEqual( 1, actual );
        }

        [Test]
        public void LastIndexOfTestCase2NullCheck()
        {
            Array array = null;
            Action test = () => array.LastIndexOf( "test2", 0, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void LastIndexOfTestCaseNullCheck()
        {
            Array array = null;
            Action test = () => array.LastIndexOf( "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}