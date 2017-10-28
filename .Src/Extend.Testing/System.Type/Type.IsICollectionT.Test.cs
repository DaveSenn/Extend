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
        public void IsICollectionTNullTest()
        {
            Type type = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => type.IsICollectionT();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsICollectionTTest()
        {
            var actual = typeof(String).IsICollectionT();
            actual.Should()
                  .BeFalse();
        }

        [Fact]
        public void IsICollectionTTest1()
        {
            var actual = typeof(List<String>).IsICollectionT();
            actual.Should()
                  .BeFalse();
        }

        [Fact]
        public void IsICollectionTTest2()
        {
            var actual = typeof(Dictionary<Int32, String>).IsICollectionT();
            actual.Should()
                  .BeFalse();
        }

        [Fact]
        public void IsICollectionTTest3()
        {
            var actual = typeof(Tuple<Int32>).IsICollectionT();
            actual.Should()
                  .BeFalse();
        }

        [Fact]
        public void IsICollectionTTest4()
        {
            var actual = typeof(ICollection<String>).IsICollectionT();
            actual.Should()
                  .BeTrue();
        }
    }
}