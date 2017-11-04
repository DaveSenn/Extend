#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void TakeAndRemoveTest()
        {
            var value = "Test";
            var actual = 2.TakeAndRemove( ref value );

            Assert.Equal( "Te", actual );
            Assert.Equal( "st", value );
        }

        [Fact]
        public void TakeAndRemoveTest1()
        {
            var value = "Test";
            var actual = 4.TakeAndRemove( ref value );

            Assert.Equal( "Test", actual );
            Assert.Equal( String.Empty, value );
        }

        [Fact]
        public void TakeAndRemoveTest2()
        {
            var value = "    ";
            var actual = 2.TakeAndRemove( ref value );

            Assert.Equal( "  ", actual );
            Assert.Equal( "  ", value );
        }

        [Fact]
        public void TakeAndRemoveTestArgumentOutOfRangeException()
        {
            var value = "Test";
            Action test = () => 5.TakeAndRemove( ref value );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TakeAndRemoveTestNullCheck()
        {
            String value = null;
            Action test = () => 2.TakeAndRemove( ref value );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}