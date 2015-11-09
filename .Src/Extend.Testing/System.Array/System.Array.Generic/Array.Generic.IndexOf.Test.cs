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
        public void GenericIndexOfTestCase()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            var actual = array.IndexOf( "test2" );
            Assert.AreEqual( 1, actual );
        }

        [Test]
        public void GenericIndexOfTestCase1()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            var actual = array.IndexOf( "test2", 1 );
            Assert.AreEqual( 1, actual );
        }

        [Test]
        public void GenericIndexOfTestCase1NullCheck()
        {
            String[] array = null;
            Action test = () => array.IndexOf( "test2", 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GenericIndexOfTestCase2()
        {
            var array = new[]
            {
                "test",
                "test2",
                "test3",
                "test4"
            };
            var actual = array.IndexOf( "test3", 1, 2 );
            Assert.AreEqual( 2, actual );
        }

        [Test]
        public void GenericIndexOfTestCase2NullCheck()
        {
            String[] array = null;
            Action test = () => array.IndexOf( "test3", 1, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GenericIndexOfTestCaseNullCheck()
        {
            String[] array = null;
            Action test = () => array.IndexOf( "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}