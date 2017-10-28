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
        public void GenericLastIndexOfTest()
        {
            var array = new[]
            {
                "test",
                "test2",
                "test2"
            };
            var actual = array.LastIndexOf( "test2" );
            Assert.Equal( 2, actual );
        }

        [Fact]
        public void GenericLastIndexOfTest1()
        {
            var array = new[]
            {
                "test",
                "test2",
                "test2"
            };
            var actual = array.LastIndexOf( "test2", 2 );
            Assert.Equal( 2, actual );
        }

        [Fact]
        public void GenericLastIndexOfTest1NullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.LastIndexOf( "test2", 1 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GenericLastIndexOfTest2()
        {
            var array = new[]
            {
                "test",
                "test2",
                "test2"
            };

            var actual = array.LastIndexOf( "test2", 1, 1 );
            Assert.Equal( 1, actual );
        }

        [Fact]
        public void GenericLastIndexOfTest2NullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.LastIndexOf( "test2", 0, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GenericLastIndexOfTestNullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.LastIndexOf( "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}