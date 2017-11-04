#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class AttributeDefinitionTypeTest
    {
        [Fact]
        public void AttributesTest()
        {
            var target = new AttributeDefinitionType<ObsoleteAttribute>();

            target.Attributes.Should()
                  .BeNull();

            var expected = new List<ObsoleteAttribute>();
            target.Attributes = expected;

            target.Attributes.Should()
                  .BeSameAs( expected );
        }

        [Fact]
        public void TypeTest()
        {
            var target = new AttributeDefinitionType<ObsoleteAttribute>();

            target.Type.Should()
                  .BeNull();

            var expected = GetType();
            target.Type = expected;

            target.Type.Should()
                  .Be( expected );
        }
    }
}