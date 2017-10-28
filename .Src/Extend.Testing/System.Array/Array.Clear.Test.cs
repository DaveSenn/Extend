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
        public void ClearTest()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            array.Clear( 0, 2 );

            Assert.Null( array.GetValue( 0 ) );
            Assert.Null( array.GetValue( 1 ) );
            Assert.Equal( "2", array.GetValue( 2 ) );
        }

        [Fact]
        public void ClearTestNullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.Clear( 0, 0 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}