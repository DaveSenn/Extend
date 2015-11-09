﻿#region Usings

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

        [Test]
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

        [Test]
        public void SliceTestCase1ArgumentOutOfRangeException()
        {
            var sourceArray = new[]
            {
                1
            };
            var targetArray = new Int32[2];

            Action test = () => sourceArray.Slice( 2, targetArray );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
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

            Action test = () => sourceArray.Slice( 2, targetArray );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void SliceTestCase1NullCheck()
        {
            Int32[] sourceArray = null;
            Action test = () => sourceArray.Slice( 2, new Int32[2] );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SliceTestCase1NullCheck1()
        {
            var sourceArray = new[]
            {
                1,
                2
            };
            Action test = () => sourceArray.Slice( 2, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
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

        [Test]
        public void SliceTestCase2ArgumentOutOfRangeException()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            Action test = () => sourceArray.Slice( 10, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void SliceTestCase2ArgumentOutOfRangeException1()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            Action test = () => sourceArray.Slice( 0, 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void SliceTestCase2ArgumentOutOfRangeException2()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            Action test = () => sourceArray.Slice( 2, 3 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void SliceTestCase2NullCheck()
        {
            Int32[] sourceArray = null;

            Action test = () => sourceArray.Slice( 2, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
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

        [Test]
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
            Action test = () => sourceArray.Slice( 10, 2, targetArray );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
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
            Action test = () => sourceArray.Slice( 0, 10, targetArray );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
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
            Action test = () => sourceArray.Slice( 2, 3, targetArray );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void SliceTestCase3ArgumentOutOfRangeException3()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            var targetArray = new Int32[4];
            Action test = () => sourceArray.Slice( -1, 3, targetArray );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void SliceTestCase3ArgumentOutOfRangeException4()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            var targetArray = new Int32[4];
            Action test = () => sourceArray.Slice( 1, -1, targetArray );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void SliceTestCase3NullCheck()
        {
            Int32[] sourceArray = null;
            Action test = () => sourceArray.Slice( 2, 2, new Int32[2] );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SliceTestCase3NullCheck1()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            Action test = () => sourceArray.Slice( 2, 2, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SliceTestCaseArgumentOutOfRangeExceptio()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };

            Action test = () => sourceArray.Slice( 10 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void SliceTestCaseNullCheck()
        {
            Int32[] sourceArray = null;

            Action test = () => sourceArray.Slice( 2 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}