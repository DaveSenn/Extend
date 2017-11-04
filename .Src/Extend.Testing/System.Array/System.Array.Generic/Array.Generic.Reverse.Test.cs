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
        public void GenericReverseTest()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            array.Reverse();

            Assert.Equal( "test2", array[0] );
            Assert.Equal( "test", array[1] );
        }

        [Fact]
        public void GenericReverseTest1()
        {
            var array = new[]
            {
                "test",
                "test2",
                "test3"
            };
            array.Reverse( 0, 2 );

            Assert.Equal( "test2", array[0] );
            Assert.Equal( "test", array[1] );
            Assert.Equal( "test3", array[2] );
        }

        [Fact]
        public void GenericReverseTest1NullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.Reverse( 1, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GenericReverseTestNullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.Reverse();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}