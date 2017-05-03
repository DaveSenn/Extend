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
        public void ClearAllTest()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            array.ClearAll();

            array.GetValue( 0 )
                 .Should()
                 .BeNull();
            array.GetValue( 1 )
                 .Should()
                 .BeNull();
            array.GetValue( 2 )
                 .Should()
                 .BeNull();
        }

        [Fact]
        public void ClearAllTestNullCheck()
        {
            Array array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => array.ClearAll();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}