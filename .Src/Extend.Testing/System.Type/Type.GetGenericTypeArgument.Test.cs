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
        public void GetGenericTypeArgumentNullValueTest()
        {
            Type type = null;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => type.GetGenericTypeArgument();
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetGenericTypeArgumentTest()
        {
            var actual = typeof(String).GetGenericTypeArgument();
            actual.Should()
                  .BeNull();
        }

        [Test]
        public void GetGenericTypeArgumentTest1()
        {
            var actual = typeof(List<String>).GetGenericTypeArgument();
            actual.Should()
                  .Be( typeof(String) );
        }

        [Test]
        public void GetGenericTypeArgumentTest2()
        {
            var actual = typeof(Dictionary<Int32, String>).GetGenericTypeArgument();
            actual.Should()
                  .Be( typeof(Int32) );
        }
    }
}