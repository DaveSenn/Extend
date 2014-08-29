#region Using

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class AttributeDefinitionTest
    {
        [Test]
        public void AttributesTestCase()
        {
            var target = new AttributeDefinition<DisplayAttribute>();
            var expected = new List<DisplayAttribute>();
            target.Attributes = expected;

            Assert.AreSame( expected, target.Attributes );
        }

        [Test]
        public void CtorTestCase()
        {
            var target = new AttributeDefinition<DisplayAttribute>();
            Assert.IsNotNull( target.Attributes );
            Assert.AreEqual( 0, target.Attributes.CountOptimized() );
        }

        [Test]
        public void PropertyTestCase()
        {
            var target = new AttributeDefinition<DisplayAttribute>();
            var expected = typeof ( DisplayAttribute ).GetProperties().First();
            target.Property = expected;

            Assert.AreSame( expected, target.Property );
        }
    }
}