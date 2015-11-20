#region Usings

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class AttributeDefinitionTypeTest
    {
        [Test]
        public void AttributesTest()
        {
            var target = new AttributeDefinitionType<DisplayAttribute>();

            target.Attributes.Should()
                  .BeNull();

            var expected = new List<DisplayAttribute>();
            target.Attributes = expected;

            target.Attributes.Should()
                  .BeSameAs( expected );
        }

        [Test]
        public void TypeTest()
        {
            var target = new AttributeDefinitionType<DisplayAttribute>();

            target.Type.Should()
                  .BeNull();

            var expected = GetType();
            target.Type = expected;

            target.Type.Should()
                  .Be( expected );
        }
    }
}