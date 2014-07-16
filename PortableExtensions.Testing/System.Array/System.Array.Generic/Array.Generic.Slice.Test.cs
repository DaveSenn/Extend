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
        public void SliceTestCase()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };

            var actual = sourceArray.Slice( 2 );

            Assert.AreEqual( 2, actual.Length );
            Assert.AreEqual( 1, actual[0] );
            Assert.AreEqual( 2, actual[1] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void SliceTestCaseArgumentOutOfRangeExceptio()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };

            var actual = sourceArray.Slice( 10 );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SliceTestCaseNullCheck()
        {
            Int32[] sourceArray = null;

            var actual = sourceArray.Slice( 2 );
        }

        [TestCase]
        public void SliceTestCase1()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            var targetArray = new Int32[2];

            var actual = sourceArray.Slice( 2, targetArray );

            Assert.AreSame( targetArray, actual );
            Assert.AreEqual( 2, actual.Length );
            Assert.AreEqual( 1, actual[0] );
            Assert.AreEqual( 2, actual[1] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void SliceTestCase1ArgumentOutOfRangeException()
        {
            var sourceArray = new[]
            {
                1
            };
            var targetArray = new Int32[2];

            var actual = sourceArray.Slice( 2, targetArray );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void SliceTestCase1ArgumentOutOfRangeException1()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            var targetArray = new Int32[1];

            var actual = sourceArray.Slice( 2, targetArray );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SliceTestCase1NullCheck()
        {
            Int32[] sourceArray = null;
            var actual = sourceArray.Slice( 2, new Int32[2] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SliceTestCase1NullCheck1()
        {
            var sourceArray = new[]
            {
                1,
                2
            };
            var actual = sourceArray.Slice( 2, null );
        }

        [TestCase]
        public void SliceTestCase2()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };

            var actual = sourceArray.Slice( 1, 2 );

            Assert.AreEqual( 2, actual.Length );
            Assert.AreEqual( 2, actual[0] );
            Assert.AreEqual( 3, actual[1] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void SliceTestCase2ArgumentOutOfRangeException()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            var actual = sourceArray.Slice( 10, 2 );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void SliceTestCase2ArgumentOutOfRangeException1()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            var actual = sourceArray.Slice( 0, 10 );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void SliceTestCase2ArgumentOutOfRangeException2()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            var actual = sourceArray.Slice( 2, 3 );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SliceTestCase2NullCheck()
        {
            Int32[] sourceArray = null;

            var actual = sourceArray.Slice( 2, 2 );
        }

        [TestCase]
        public void SliceTestCase3()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            var targetArray = new Int32[2];

            var actual = sourceArray.Slice( 1, 2, targetArray );

            Assert.AreSame( targetArray, actual );
            Assert.AreEqual( 2, actual.Length );
            Assert.AreEqual( 2, actual[0] );
            Assert.AreEqual( 3, actual[1] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void SliceTestCase3ArgumentOutOfRangeException()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            var targetArray = new Int32[4];
            var actual = sourceArray.Slice( 10, 2, targetArray );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void SliceTestCase3ArgumentOutOfRangeException1()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            var targetArray = new Int32[4];
            var actual = sourceArray.Slice( 0, 10, targetArray );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentOutOfRangeException ) )]
        public void SliceTestCase3ArgumentOutOfRangeException2()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            var targetArray = new Int32[4];
            var actual = sourceArray.Slice( 2, 3, targetArray );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SliceTestCase3NullCheck()
        {
            Int32[] sourceArray = null;
            var actual = sourceArray.Slice( 2, 2, new Int32[2] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SliceTestCase3NullCheck1()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            var actual = sourceArray.Slice( 2, 2, null );
        }
    }
}