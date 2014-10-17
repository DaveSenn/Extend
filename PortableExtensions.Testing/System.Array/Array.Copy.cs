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
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void CopyAllTestCaseNullCheck ()
        {
            Array array = null;
            var destinationArray = new String[10];
            array.Copy( destinationArray, 1 );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void CopyAllTestCaseNullCheck1 ()
        {
            Array array = new String[10];
            String[] destinationArray = null;
            array.Copy( destinationArray, 1 );
        }

        [Test]
        public void CopyTestCase ()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var destinationArray = new String[3];
            array.Copy( destinationArray, 3 );

            Assert.AreEqual( "0", destinationArray [0] );
            Assert.AreEqual( "1", destinationArray [1] );
            Assert.AreEqual( "2", destinationArray [2] );
        }

        [Test]
        public void CopyTestCase1 ()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2",
                "3"
            };
            var destinationArray = new String[2];
            array.Copy( 1, destinationArray, 0, 2 );

            Assert.AreEqual( "1", destinationArray [0] );
            Assert.AreEqual( "2", destinationArray [1] );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentException) )]
        public void CopyTestCase1ArgumentException ()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2",
                "3"
            };
            var destinationArray = new String[2];
            array.Copy( 0, destinationArray, 1, 20 );

            Assert.AreEqual( "1", destinationArray [0] );
            Assert.AreEqual( "2", destinationArray [1] );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentOutOfRangeException) )]
        public void CopyTestCase1ArgumentOutOfRangeException ()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2",
                "3"
            };
            var destinationArray = new String[2];
            array.Copy( -1, destinationArray, 0, 2 );

            Assert.AreEqual( "1", destinationArray [0] );
            Assert.AreEqual( "2", destinationArray [1] );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentOutOfRangeException) )]
        public void CopyTestCase1ArgumentOutOfRangeException1 ()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2",
                "3"
            };
            var destinationArray = new String[2];
            array.Copy( 0, destinationArray, -1, 2 );

            Assert.AreEqual( "1", destinationArray [0] );
            Assert.AreEqual( "2", destinationArray [1] );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentOutOfRangeException) )]
        public void CopyTestCase1ArgumentOutOfRangeException2 ()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2",
                "3"
            };
            var destinationArray = new String[2];
            array.Copy( 0, destinationArray, 1, -1 );

            Assert.AreEqual( "1", destinationArray [0] );
            Assert.AreEqual( "2", destinationArray [1] );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void CopyTestCase1NullCheck ()
        {
            Array array = null;
            var destinationArray = new String[2];
            array.Copy( 1, destinationArray, 0, 2 );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void CopyTestCase1NullCheck1 ()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2",
                "3"
            };
            String[] destinationArray = null;
            array.Copy( 1, destinationArray, 0, 2 );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentException) )]
        public void CopyTestCaseArgumentException ()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var destinationArray = new String[3];
            array.Copy( destinationArray, 30 );

            Assert.AreEqual( "0", destinationArray [0] );
            Assert.AreEqual( "1", destinationArray [1] );
            Assert.AreEqual( "2", destinationArray [2] );
        }
    }
}