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
        public void IsIListTNullTest()
        {
            Type type = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => type.IsIListT();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsIListTTest()
        {
            var actual = typeof(String).IsIListT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsIListTTest1()
        {
            var actual = typeof(List<String>).IsIListT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsIListTTest2()
        {
            var actual = typeof(Dictionary<Int32, String>).IsIListT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsIListTTest3()
        {
            var actual = typeof(Tuple<Int32>).IsIListT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsIListTTest4()
        {
            var actual = typeof(IList<String>).IsIListT();
            actual.Should()
                  .BeTrue();
        }
    }
}