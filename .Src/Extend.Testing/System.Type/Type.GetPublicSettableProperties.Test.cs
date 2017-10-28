#region Usings

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class TypeExTest
    {
        [Fact]
        public void GetPublicSettablePropertiesTest()
        {
            var type = typeof(TestModel);
            var actual = type.GetPublicSettableProperties()
                             .ToList();

            actual.Count.Should()
                  .Be( 2 );

            actual.Count( x => x.Name == "MyString" )
                  .Should()
                  .Be( 1 );

            actual.Count( x => x.Name == "MyInt32" )
                  .Should()
                  .Be( 1 );
        }

        [Fact]
        public void GetPublicSettablePropertiesTest1()
        {
            var type = typeof(TestModelNoProperties);
            var actual = type.GetPublicSettableProperties()
                             .ToList();

            actual.Count.Should()
                  .Be( 0 );
        }

        #region Nested Types

        private class TestModel
        {
            // ReSharper disable UnusedMember.Local
            public String MyString { get; set; }

            public Int32 MyInt32 { get; set; }

            // ReSharper disable once UnusedMember.Local
            // ReSharper disable once UnassignedGetOnlyAutoProperty
            public String ReadonlyString { get; }

            private String PrivateString { get; set; }

            // ReSharper disable once UnassignedGetOnlyAutoProperty
            public Int32 MyReadonlyInt32 { get; }

            // ReSharper disable once UnassignedGetOnlyAutoProperty
            public String MyReadonlyString { get; }
            // ReSharper restore UnusedMember.Local
        }

        private class TestModelNoProperties
        {
        }

        #endregion
    }
}