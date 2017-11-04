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
        public void CopyAllTestNullCheck()
        {
            Array array = null;
            var destinationArray = new String[10];
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.Copy( destinationArray, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CopyAllTestNullCheck1()
        {
            Array array = new String[10];
            String[] destinationArray = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.Copy( destinationArray, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CopyTest()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var destinationArray = new String[3];
            array.Copy( destinationArray, 3 );

            Assert.Equal( "0", destinationArray[0] );
            Assert.Equal( "1", destinationArray[1] );
            Assert.Equal( "2", destinationArray[2] );
        }

        [Fact]
        public void CopyTest1()
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

            Assert.Equal( "1", destinationArray[0] );
            Assert.Equal( "2", destinationArray[1] );
        }

        [Fact]
        public void CopyTest1ArgumentException()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2",
                "3"
            };
            var destinationArray = new String[2];
            Action test = () => array.Copy( 0, destinationArray, 1, 20 );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void CopyTest1ArgumentOutOfRangeException()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2",
                "3"
            };
            var destinationArray = new String[2];
            Action test = () => array.Copy( -1, destinationArray, 0, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CopyTest1ArgumentOutOfRangeException1()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2",
                "3"
            };
            var destinationArray = new String[2];
            Action test = () => array.Copy( 0, destinationArray, -1, 2 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CopyTest1ArgumentOutOfRangeException2()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2",
                "3"
            };
            var destinationArray = new String[2];
            Action test = () => array.Copy( 0, destinationArray, 1, -1 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CopyTest1NullCheck()
        {
            Array array = null;
            var destinationArray = new String[2];
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.Copy( 1, destinationArray, 0, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CopyTest1NullCheck1()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2",
                "3"
            };
            String[] destinationArray = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.Copy( 1, destinationArray, 0, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CopyTestArgumentException()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var destinationArray = new String[3];
            Action test = () => array.Copy( destinationArray, 30 );

            test.ShouldThrow<ArgumentException>();
        }
    }
}