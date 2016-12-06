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
        public void GetTypeFromNullableNullValueTest()
        {
            Type type = null;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => type.GetTypeFromNullable();
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetTypeFromNullableTest()
        {
            var type = typeof(Int32?);
            var actual = type.GetTypeFromNullable();

            actual.Should()
                  .Be( typeof(Int32) );
        }

        [Test]
        public void GetTypeFromNullableTest1()
        {
            var type = typeof(Double?);
            var actual = type.GetTypeFromNullable();

            actual.Should()
                  .Be( typeof(Double) );
        }

        [Test]
        public void GetTypeFromNullableTest2()
        {
            var type = typeof(String);
            var actual = type.GetTypeFromNullable();

            actual.Should()
                  .BeNull();
        }

        [Test]
        public void GetTypeFromNullableTest3()
        {
            var type = typeof(List<String>);
            var actual = type.GetTypeFromNullable();

            actual.Should()
                  .BeNull();
        }
    }
}