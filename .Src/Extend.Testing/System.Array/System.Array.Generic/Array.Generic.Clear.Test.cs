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
        public void GenericClearTest()
        {
            var array = new[]
            {
                "test",
                "test"
            };
            array.Clear( 0, 2 );

            Assert.Null( array[0] );
            Assert.Null( array[1] );
        }

        [Fact]
        public void GenericClearTest1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ArrayEx.Clear<String>( null, 0, 2 );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}