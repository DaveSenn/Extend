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
        public void GenericClearAllTest()
        {
            var array = new[]
            {
                "test",
                "test"
            };
            array.ClearAll();

            Assert.Null( array[0] );
            Assert.Null( array[1] );
        }

        [Fact]
        public void GenericClearAllTest1()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.ClearAll();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}