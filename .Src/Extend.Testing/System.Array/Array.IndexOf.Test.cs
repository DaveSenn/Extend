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
        public void IndexOfTest()
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
        public void IndexOfTest1()
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
        public void IndexOfTest1NullCheck()
        {
            Array array = null;
            Action test = () => array.IndexOf( "test", 10 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IndexOfTest2()
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
        public void IndexOfTest2NullCheck()
        {
            Array array = null;
            Action test = () => array.IndexOf( "test", 10, 12 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IndexOfTestNullCheck()
        {
            Array array = null;
            Action test = () => array.IndexOf( "test" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}