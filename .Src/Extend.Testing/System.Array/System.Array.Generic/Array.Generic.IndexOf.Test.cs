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
        public void GenericIndexOfTest()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            var actual = array.IndexOf( "test2" );
            Assert.AreEqual( 1, actual );
        }

        [Test]
        public void GenericIndexOfTest1()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            var actual = array.IndexOf( "test2", 1 );
            Assert.AreEqual( 1, actual );
        }

        [Test]
        public void GenericIndexOfTest1NullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.IndexOf( "test2", 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GenericIndexOfTest2()
        {
            var array = new[]
            {
                "test",
                "test2",
                "test3",
                "test4"
            };
            var actual = array.IndexOf( "test3", 1, 2 );
            Assert.AreEqual( 2, actual );
        }

        [Test]
        public void GenericIndexOfTest2NullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.IndexOf( "test3", 1, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GenericIndexOfTestNullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.IndexOf( "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}