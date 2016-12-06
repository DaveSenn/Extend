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
        public void ImplementsICollectionTNullTest()
        {
            Type type = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => type.ImplementsICollectionT();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ImplementsICollectionTTest()
        {
            var actual = typeof(String).ImplementsICollectionT();
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void ImplementsICollectionTTest1()
        {
            var actual = typeof(List<String>).ImplementsICollectionT();
            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void ImplementsICollectionTTest2()
        {
            var actual = typeof(Dictionary<Int32, String>).ImplementsICollectionT();
            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void ImplementsICollectionTTest3()
        {
            var actual = typeof(Tuple<Int32>).ImplementsICollectionT();
            actual.Should()
                  .BeFalse();
        }
    }
}