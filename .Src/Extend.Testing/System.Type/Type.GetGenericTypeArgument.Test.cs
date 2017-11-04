#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class TypeExTest
    {
        [Fact]
        public void GetGenericTypeArgumentNullValueTest()
        {
            Type type = null;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => type.GetGenericTypeArgument();
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetGenericTypeArgumentTest()
        {
            var actual = typeof(String).GetGenericTypeArgument();
            actual.Should()
                  .BeNull();
        }

        [Fact]
        public void GetGenericTypeArgumentTest1()
        {
            var actual = typeof(List<String>).GetGenericTypeArgument();
            actual.Should()
                  .Be( typeof(String) );
        }

        [Fact]
        public void GetGenericTypeArgumentTest2()
        {
            var actual = typeof(Dictionary<Int32, String>).GetGenericTypeArgument();
            actual.Should()
                  .Be( typeof(Int32) );
        }
    }
}