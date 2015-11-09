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
        public void GenericLastIndexOfTestCase()
        {
            var array = new[]
            {
                "test",
                "test2",
                "test2"
            };
            var actual = array.LastIndexOf( "test2" );
            Assert.AreEqual( 2, actual );
        }

        [Test]
        public void GenericLastIndexOfTestCase1()
        {
            var array = new[]
            {
                "test",
                "test2",
                "test2"
            };
            var actual = array.LastIndexOf( "test2", 2 );
            Assert.AreEqual( 2, actual );
        }

        [Test]
        public void GenericLastIndexOfTestCase1NullCheck()
        {
            String[] array = null;
            Action test = () => array.LastIndexOf( "test2", 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GenericLastIndexOfTestCase2()
        {
            var array = new[]
            {
                "test",
                "test2",
                "test2"
            };

            var actual = array.LastIndexOf( "test2", 1, 1 );
            Assert.AreEqual( 1, actual );
        }

        [Test]
        public void GenericLastIndexOfTestCase2NullCheck()
        {
            String[] array = null;
            Action test = () => array.LastIndexOf( "test2", 0, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GenericLastIndexOfTestCaseNullCheck()
        {
            String[] array = null;
            Action test = () => array.LastIndexOf( "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}