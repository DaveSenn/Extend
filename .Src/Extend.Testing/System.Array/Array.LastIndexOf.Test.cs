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
        public void LastIndexOfTest()
        {
            Array array = new[]
            {
                "test",
                "test2",
                "test2"
            };
            var actual = array.LastIndexOf( "test2" );
            Assert.Equal( 2, actual );
        }

        [Fact]
        public void LastIndexOfTest1()
        {
            Array array = new[]
            {
                "test",
                "test2",
                "test2"
            };
            var actual = array.LastIndexOf( "test2", 2 );
            Assert.Equal( 2, actual );
        }

        [Fact]
        public void LastIndexOfTest1NullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.LastIndexOf( "test2", 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void LastIndexOfTest2()
        {
            Array array = new[]
            {
                "test",
                "test2",
                "test2"
            };
            var actual = array.LastIndexOf( "test2", 1, 2 );
            Assert.Equal( 1, actual );
        }

        [Fact]
        public void LastIndexOfTest2NullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.LastIndexOf( "test2", 0, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void LastIndexOfTestNullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.LastIndexOf( "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}