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
        public void GetTypeFromNullableNullValueTest()
        {
            Type type = null;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => type.GetTypeFromNullable();
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetTypeFromNullableTest()
        {
            var type = typeof(Int32?);
            var actual = type.GetTypeFromNullable();

            actual.Should()
                  .Be( typeof(Int32) );
        }

        [Fact]
        public void GetTypeFromNullableTest1()
        {
            var type = typeof(Double?);
            var actual = type.GetTypeFromNullable();

            actual.Should()
                  .Be( typeof(Double) );
        }

        [Fact]
        public void GetTypeFromNullableTest2()
        {
            var type = typeof(String);
            var actual = type.GetTypeFromNullable();

            actual.Should()
                  .BeNull();
        }

        [Fact]
        public void GetTypeFromNullableTest3()
        {
            var type = typeof(List<String>);
            var actual = type.GetTypeFromNullable();

            actual.Should()
                  .BeNull();
        }
    }
}