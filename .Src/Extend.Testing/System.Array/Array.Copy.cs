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
        public void CopyAllTestCaseNullCheck()
        {
            Array array = null;
            var destinationArray = new String[10];
            Action test = () => array.Copy( destinationArray, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CopyAllTestCaseNullCheck1()
        {
            Array array = new String[10];
            String[] destinationArray = null;
            Action test = () => array.Copy( destinationArray, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CopyTestCase()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var destinationArray = new String[3];
            array.Copy( destinationArray, 3 );

            Assert.AreEqual( "0", destinationArray[0] );
            Assert.AreEqual( "1", destinationArray[1] );
            Assert.AreEqual( "2", destinationArray[2] );
        }

        [Test]
        public void CopyTestCase1()
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

            Assert.AreEqual( "1", destinationArray[0] );
            Assert.AreEqual( "2", destinationArray[1] );
        }

        [Test]
        public void CopyTestCase1ArgumentException()
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

        [Test]
        public void CopyTestCase1ArgumentOutOfRangeException()
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

        [Test]
        public void CopyTestCase1ArgumentOutOfRangeException1()
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

        [Test]
        public void CopyTestCase1ArgumentOutOfRangeException2()
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

        [Test]
        public void CopyTestCase1NullCheck()
        {
            Array array = null;
            var destinationArray = new String[2];
            Action test = () => array.Copy( 1, destinationArray, 0, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CopyTestCase1NullCheck1()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2",
                "3"
            };
            String[] destinationArray = null;
            Action test = () => array.Copy( 1, destinationArray, 0, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CopyTestCaseArgumentException()
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