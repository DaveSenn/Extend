#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void AsTest()
        {
            Object value = 10;
            var actual = value.As<Int32>();

            Assert.Equal( value, actual );
        }

        [Fact]
        public void AsTestNullValue()
        {
            var res = ObjectEx.As<String>( null );
            res.Should()
               .BeNull();
        }
    }
}