#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class TypeExTest
    {
        [Test]
        public void IsEnumNullTest()
        {
            Type type = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => type.IsEnum();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsEnumTest()
        {
            var actual = typeof(String).IsEnum();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsEnumTest1()
        {
            var actual = typeof(List<String>).IsEnum();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsEnumTest2()
        {
            var actual = typeof(Dictionary<Int32, String>).IsEnum();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsEnumTest3()
        {
            var actual = typeof(Tuple<Int32>).IsEnum();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsEnumTest4()
        {
            var actual = typeof(DayOfWeek).IsEnum();
            actual.Should()
                  .BeTrue();
        }
    }
}