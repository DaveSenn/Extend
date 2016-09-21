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
        public void IsIEnumerableTNullTest()
        {
            Type type = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => type.IsIEnumerableT();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsIEnumerableTTest()
        {
            var actual = typeof(String).IsIEnumerableT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsIEnumerableTTest1()
        {
            var actual = typeof(List<String>).IsIEnumerableT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsIEnumerableTTest2()
        {
            var actual = typeof(Dictionary<Int32, String>).IsIEnumerableT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsIEnumerableTTest3()
        {
            var actual = typeof(Tuple<Int32>).IsIEnumerableT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsIEnumerableTTest4()
        {
            var actual = typeof(IEnumerable<String>).IsIEnumerableT();
            actual.Should()
                  .BeTrue();
        }
    }
}