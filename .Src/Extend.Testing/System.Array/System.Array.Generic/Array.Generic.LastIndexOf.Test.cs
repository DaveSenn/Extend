#region Usings

using System;
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

            Assert.Throws<ArgumentNullException>( test );
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

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void GenericLastIndexOfTestNullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.LastIndexOf( "test2" );

            Assert.Throws<ArgumentNullException>( test );
        }
    }
}