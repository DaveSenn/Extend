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
        public void ReverseTest()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            array.Reverse();

            Assert.Equal( "2", array.GetValue( 0 ) );
            Assert.Equal( "1", array.GetValue( 1 ) );
            Assert.Equal( "0", array.GetValue( 2 ) );
        }

        [Fact]
        public void ReverseTest1()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            array.Reverse( 1, 2 );

            Assert.Equal( "0", array.GetValue( 0 ) );
            Assert.Equal( "2", array.GetValue( 1 ) );
            Assert.Equal( "1", array.GetValue( 2 ) );
        }

        [Fact]
        public void ReverseTest1NullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.Reverse( 1, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ReverseTestNullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.Reverse();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}