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
        public void ToListTest()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var list = array.ToList( x => "test" + x );

            Assert.Equal( "test0", list[0] );
            Assert.Equal( "test1", list[1] );
            Assert.Equal( "test2", list[2] );
        }

        [Fact]
        public void ToListTestNullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.ToList( x => "test" + x );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToListTestNullCheck1()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            Func<Object, String> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.ToList( func );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}