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
        public void GenericIndexOfTest()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            var actual = array.IndexOf( "test2" );
            Assert.Equal( 1, actual );
        }

        [Fact]
        public void GenericIndexOfTest1()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            var actual = array.IndexOf( "test2", 1 );
            Assert.Equal( 1, actual );
        }

        [Fact]
        public void GenericIndexOfTest1NullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.IndexOf( "test2", 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
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
            Assert.Equal( 2, actual );
        }

        [Fact]
        public void GenericIndexOfTest2NullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.IndexOf( "test3", 1, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
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