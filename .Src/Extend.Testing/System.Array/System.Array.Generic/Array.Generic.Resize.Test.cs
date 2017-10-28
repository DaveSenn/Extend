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
        public void GenericResizeTest()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            array = array.Resize( 10 );
            Assert.Equal( 10, array.Length );
        }

        [Fact]
        public void GenericResizeTestNullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.Resize( 10 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}