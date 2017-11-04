#region Usings

// ReSharper disable once RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using System.Reflection;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class AttributeDefinitionPropertyTest
    {
        [Fact]
        public void AttributesTest()
        {
            var target = new AttributeDefinitionProperty<MyDisplayAttribute>();
            var expected = new List<MyDisplayAttribute>();
            target.Attributes = expected;

            target.Attributes.Should()
                  .BeSameAs( expected );
        }

        [Fact]
        public void CtorTest()
        {
            var target = new AttributeDefinitionProperty<MyDisplayAttribute>();

            target.Attributes.Should()
                  .HaveCount( 0 );
        }

        [Fact]
        public void PropertyTest()
        {
            var target = new AttributeDefinitionProperty<MyDisplayAttribute>();
            var expected = typeof(MyDisplayAttribute).GetProperties()
                                                     .First();
            target.Property = expected;

            target.Property.Should()
                  .BeSameAs( expected );
        }

        #region Nested Types

        [AttributeUsage( AttributeTargets.Property, AllowMultiple = true )]
        private class MyDisplayAttribute : Attribute
        {
            #region Properties

            // ReSharper disable once UnusedMember.Local
            public String Name { get; set; }

            #endregion
        }

        #endregion
    }
}