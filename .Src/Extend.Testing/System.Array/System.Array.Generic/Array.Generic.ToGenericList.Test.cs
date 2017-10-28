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
        public void GenericToListTest()
        {
            var array = new[]
            {
                1,
                2,
                3
            };
            var list = array.ToGenericList( x => 10 + x );

            Assert.Equal( 11, list[0] );
            Assert.Equal( 12, list[1] );
            Assert.Equal( 13, list[2] );
        }

        [Fact]
        public void GenericToListTestNullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.ToGenericList( x => x + "Test" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GenericToListTestNullCheck1()
        {
            var array = new[]
            {
                1,
                2,
                3
            };
            Func<Int32, Int32> selector = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.ToGenericList( selector );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}