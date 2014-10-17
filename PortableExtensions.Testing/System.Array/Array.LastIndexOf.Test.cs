#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void LastIndexOfTestCase ()
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
        public void LastIndexOfTestCase1 ()
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
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void LastIndexOfTestCase1NullCheck ()
        {
            Array array = null;
            var actual = array.LastIndexOf( "test2", 1 );
            Assert.AreEqual( 2, actual );
        }

        [Test]
        public void LastIndexOfTestCase2 ()
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
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void LastIndexOfTestCase2NullCheck ()
        {
            Array array = null;
            var actual = array.LastIndexOf( "test2", 0, 2 );
            Assert.AreEqual( 2, actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void LastIndexOfTestCaseNullCheck ()
        {
            Array array = null;
            var actual = array.LastIndexOf( "test2" );
            Assert.AreEqual( 2, actual );
        }
    }
}