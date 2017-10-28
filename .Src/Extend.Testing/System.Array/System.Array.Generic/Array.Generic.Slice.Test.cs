#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ArrayExTest
    {
        [Fact]
        public void SliceTest()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };

            var actual = sourceArray.Slice( 2 );

            Assert.Equal( 2, actual.Length );
            Assert.Equal( 1, actual[0] );
            Assert.Equal( 2, actual[1] );
        }

        [Fact]
        public void SliceTest1()
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

            Assert.Same( targetArray, actual );
            Assert.Equal( 2, actual.Length );
            Assert.Equal( 1, actual[0] );
            Assert.Equal( 2, actual[1] );
        }

        [Fact]
        public void SliceTest1ArgumentOutOfRangeException()
        {
            var sourceArray = new[]
            {
                1
            };
            var targetArray = new Int32[2];

            Action test = () => sourceArray.Slice( 2, targetArray );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void SliceTest1ArgumentOutOfRangeException1()
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

        [Fact]
        public void SliceTest1NullCheck()
        {
            Int32[] sourceArray = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => sourceArray.Slice( 2, new Int32[2] );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SliceTest1NullCheck1()
        {
            var sourceArray = new[]
            {
                1,
                2
            };
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => sourceArray.Slice( 2, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SliceTest2()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };

            var actual = sourceArray.Slice( 1, 2 );

            Assert.Equal( 2, actual.Length );
            Assert.Equal( 2, actual[0] );
            Assert.Equal( 3, actual[1] );
        }

        [Fact]
        public void SliceTest2ArgumentOutOfRangeException()
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

        [Fact]
        public void SliceTest2ArgumentOutOfRangeException1()
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

        [Fact]
        public void SliceTest2ArgumentOutOfRangeException2()
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

        [Fact]
        public void SliceTest2NullCheck()
        {
            Int32[] sourceArray = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => sourceArray.Slice( 2, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SliceTest3()
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

            Assert.Same( targetArray, actual );
            Assert.Equal( 2, actual.Length );
            Assert.Equal( 2, actual[0] );
            Assert.Equal( 3, actual[1] );
        }

        [Fact]
        public void SliceTest3ArgumentOutOfRangeException()
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

        [Fact]
        public void SliceTest3ArgumentOutOfRangeException1()
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

        [Fact]
        public void SliceTest3ArgumentOutOfRangeException2()
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

        [Fact]
        public void SliceTest3ArgumentOutOfRangeException3()
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

        [Fact]
        public void SliceTest3ArgumentOutOfRangeException4()
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

        [Fact]
        public void SliceTest3NullCheck()
        {
            Int32[] sourceArray = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => sourceArray.Slice( 2, 2, new Int32[2] );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SliceTest3NullCheck1()
        {
            var sourceArray = new[]
            {
                1,
                2,
                3,
                4
            };
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => sourceArray.Slice( 2, 2, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SliceTestArgumentOutOfRangeExceptio()
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

        [Fact]
        public void SliceTestNullCheck()
        {
            Int32[] sourceArray = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => sourceArray.Slice( 2 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}