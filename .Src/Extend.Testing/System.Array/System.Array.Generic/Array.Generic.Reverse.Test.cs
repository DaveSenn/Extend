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
        public void GenericReverseTestCase()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            array.Reverse();

            Assert.AreEqual( "test2", array[0] );
            Assert.AreEqual( "test", array[1] );
        }

        [Test]
        public void GenericReverseTestCase1()
        {
            var array = new[]
            {
                "test",
                "test2",
                "test3"
            };
            array.Reverse( 0, 2 );

            Assert.AreEqual( "test2", array[0] );
            Assert.AreEqual( "test", array[1] );
            Assert.AreEqual( "test3", array[2] );
        }

        [Test]
        public void GenericReverseTestCase1NullCheck()
        {
            String[] array = null;
            Action test = () => array.Reverse( 1, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GenericReverseTestCaseNullCheck()
        {
            String[] array = null;
            Action test = () => array.Reverse();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}