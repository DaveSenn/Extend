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
        public void IsICollectionTNullTest()
        {
            Type type = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => type.IsICollectionT();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsICollectionTTest()
        {
            var actual = typeof(String).IsICollectionT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsICollectionTTest1()
        {
            var actual = typeof(List<String>).IsICollectionT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsICollectionTTest2()
        {
            var actual = typeof(Dictionary<Int32, String>).IsICollectionT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsICollectionTTest3()
        {
            var actual = typeof(Tuple<Int32>).IsICollectionT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void IsICollectionTTest4()
        {
            var actual = typeof(ICollection<String>).IsICollectionT();
            actual.Should()
                  .BeTrue();
        }
    }
}