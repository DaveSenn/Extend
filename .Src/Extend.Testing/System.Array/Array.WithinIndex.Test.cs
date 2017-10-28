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
        public void WithinIndexTest()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };

            var actual = array.WithinIndex( 2 );
            Assert.True( actual );

            actual = array.WithinIndex( -1 );
            Assert.False( actual );

            actual = array.WithinIndex( 5 );
            Assert.False( actual );
        }

        [Fact]
        public void WithinIndexTestNullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => array.WithinIndex( 10 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}