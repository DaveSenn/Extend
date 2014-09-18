#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
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
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GenericIndexOfTestCaseNullCheck()
        {
            String[] array = null;
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
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GenericIndexOfTestCase1NullCheck()
        {
            String[] array = null;
            var actual = array.IndexOf( "test2", 1 );
            Assert.AreEqual( 1, actual );
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
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GenericIndexOfTestCase2NullCheck()
        {
            String[] array = null;
            var actual = array.IndexOf( "test3", 1, 2 );
            Assert.AreEqual( 2, actual );
        }
    }
}