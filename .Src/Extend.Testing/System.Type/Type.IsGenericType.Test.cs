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
        public void IsGenericTypeNullTest()
        {
            Type type = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => type.IsGenericType();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsGenericTypeTest()
        {
            var actual = typeof(String).IsGenericType();
            actual.Should()
                  .BeFalse();
        }

        [Fact]
        public void IsGenericTypeTest1()
        {
            var actual = typeof(List<String>).IsGenericType();
            actual.Should()
                  .BeTrue();
        }

        [Fact]
        public void IsGenericTypeTest2()
        {
            var actual = typeof(Dictionary<Int32, String>).IsGenericType();
            actual.Should()
                  .BeTrue();
        }

        [Fact]
        public void IsGenericTypeTest3()
        {
            var actual = typeof(Tuple<Int32>).IsGenericType();
            actual.Should()
                  .BeTrue();
        }

        [Fact]
        public void IsGenericTypeTest4()
        {
            var actual = typeof(DayOfWeek).IsGenericType();
            actual.Should()
                  .BeFalse();
        }
    }
}