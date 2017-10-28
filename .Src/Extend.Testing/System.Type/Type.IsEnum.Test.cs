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
        public void IsEnumNullTest()
        {
            Type type = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => type.IsEnum();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsEnumTest()
        {
            var actual = typeof(String).IsEnum();
            actual.Should()
                  .BeFalse();
        }

        [Fact]
        public void IsEnumTest1()
        {
            var actual = typeof(List<String>).IsEnum();
            actual.Should()
                  .BeFalse();
        }

        [Fact]
        public void IsEnumTest2()
        {
            var actual = typeof(Dictionary<Int32, String>).IsEnum();
            actual.Should()
                  .BeFalse();
        }

        [Fact]
        public void IsEnumTest3()
        {
            var actual = typeof(Tuple<Int32>).IsEnum();
            actual.Should()
                  .BeFalse();
        }

        [Fact]
        public void IsEnumTest4()
        {
            var actual = typeof(DayOfWeek).IsEnum();
            actual.Should()
                  .BeTrue();
        }
    }
}