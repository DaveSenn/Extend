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
        public void IndexOfTest()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var actual = array.IndexOf( "1" );

            Assert.Equal( 1, actual );
        }

        [Fact]
        public void IndexOfTest1()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var actual = array.IndexOf( "1", 2 );

            Assert.Equal( -1, actual );
        }

        [Fact]
        public void IndexOfTest1NullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.IndexOf( "test", 10 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IndexOfTest2()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };

            var actual = array.IndexOf( "1", 0, 2 );
            Assert.Equal( 1, actual );

            actual = array.IndexOf( "2", 0, 2 );
            Assert.Equal( -1, actual );
        }

        [Fact]
        public void IndexOfTest2NullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.IndexOf( "test", 10, 12 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IndexOfTestNullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.IndexOf( "test" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}