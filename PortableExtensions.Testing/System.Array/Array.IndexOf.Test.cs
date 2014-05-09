#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [TestCase]
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

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IndexOfTestCaseNullCheck()
        {
            Array array = null;
            array.IndexOf( "test" );
        }

        [TestCase]
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

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IndexOfTestCase1NullCheck()
        {
            Array array = null;
            array.IndexOf( "test", 10 );
        }

        [TestCase]
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

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IndexOfTestCase2NullCheck()
        {
            Array array = null;
            array.IndexOf( "test", 10, 12 );
        }
    }
}