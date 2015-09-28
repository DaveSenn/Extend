#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class TypeExTest
    {
        [Test]
        public void CreateInstanceBuilderTest()
        {
            var type = typeof (String);
            var actual = type.CreateInstanceBuilder();

            actual.InstanceType.Should()
                  .Be( type );
            actual.Factories.Count.Should()
                  .Be( 0 );
        }

        [Test]
        public void CreateInstanceBuilderTestArgumentNullException()
        {
            Type type = null;
            Action test = () => type.CreateInstanceBuilder();
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}