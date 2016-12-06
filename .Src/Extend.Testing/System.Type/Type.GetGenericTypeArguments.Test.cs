#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class TypeExTest
    {
        [Test]
        public void GetGenericTypeArgumentsNullValueTest()
        {
            Type type = null;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => type.GetGenericTypeArguments();
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetGenericTypeArgumentsTest()
        {
            var actual = typeof(String).GetGenericTypeArguments();
            actual.Should()
                  .HaveCount( 0 );
        }

        [Test]
        public void GetGenericTypeArgumentsTest1()
        {
            var actual = typeof(List<String>).GetGenericTypeArguments();
            actual.Should()
                  .HaveCount( 1 );
            actual.First()
                  .Should()
                  .Be( typeof(String) );
        }

        [Test]
        public void GetGenericTypeArgumentsTest2()
        {
            var actual = typeof(Dictionary<Int32, String>).GetGenericTypeArguments();
            actual.Should()
                  .HaveCount( 2 );
            actual.First()
                  .Should()
                  .Be( typeof(Int32) );
            actual.Last()
                  .Should()
                  .Be( typeof(String) );
        }
    }
}