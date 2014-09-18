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
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GenericLastIndexOfTestCaseNullCheck()
        {
            String[] array = null;
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
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GenericLastIndexOfTestCase1NullCheck()
        {
            String[] array = null;
            var actual = array.LastIndexOf( "test2", 1 );
            Assert.AreEqual( 2, actual );
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
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GenericLastIndexOfTestCase2NullCheck()
        {
            String[] array = null;
            var actual = array.LastIndexOf( "test2", 0, 2 );
            Assert.AreEqual( 2, actual );
        }
    }
}