#region Usings

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class AttributeDefinitionTest
    {
        [Test]
        public void AttributesTest()
        {
            var target = new AttributeDefinition<DisplayAttribute>();
            var expected = new List<DisplayAttribute>();
            target.Attributes = expected;

            target.Attributes.Should()
                  .BeSameAs( expected );
        }

        [Test]
        public void CtorTest()
        {
            var target = new AttributeDefinition<DisplayAttribute>();

            target.Attributes.Should()
                  .HaveCount( 0 );
        }

        [Test]
        public void PropertyTest()
        {
            var target = new AttributeDefinition<DisplayAttribute>();
            var expected = typeof (DisplayAttribute).GetProperties()
                                                    .First();
            target.Property = expected;

            target.Property.Should()
                  .BeSameAs( expected );
        }
    }
}