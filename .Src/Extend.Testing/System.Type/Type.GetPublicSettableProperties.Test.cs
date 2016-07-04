#region Usings

using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class TypeExTest
    {
        private class TestModel
        {
            #region Properties

            public String MyString { get; set; }
            public Int32 MyInt32 { get; set; }
            public String ReadonlyString { get; }
            private String PrivateString { get; set; }

            #endregion
        }

        private class TestModelNoProperties
        {
        }

        [Test]
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

        [Test]
        public void GetPublicSettablePropertiesTest1()
        {
            var type = typeof(TestModelNoProperties);
            var actual = type.GetPublicSettableProperties()
                             .ToList();

            actual.Count.Should()
                  .Be( 0 );
        }
    }
}