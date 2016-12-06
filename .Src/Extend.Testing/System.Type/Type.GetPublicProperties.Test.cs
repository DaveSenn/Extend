#region Usings

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
        public void GetPublicPropertiesTest()
        {
            var type = typeof(TestModel);
            var actual = type.GetPublicProperties()
                             .ToList();

            actual.Count.Should()
                  .Be( 5 );

            actual.Count( x => x.Name == "MyString" )
                  .Should()
                  .Be( 1 );

            actual.Count( x => x.Name == "MyInt32" )
                  .Should()
                  .Be( 1 );

            actual.Count( x => x.Name == "MyReadonlyInt32" )
                  .Should()
                  .Be( 1 );

            actual.Count( x => x.Name == "MyReadonlyString" )
                  .Should()
                  .Be( 1 );

            actual.Count( x => x.Name == "ReadonlyString" )
                  .Should()
                  .Be( 1 );
        }

        [Test]
        public void GetPublicPropertiesTest1()
        {
            var type = typeof(TestModelNoProperties);
            var actual = type.GetPublicProperties()
                             .ToList();

            actual.Count.Should()
                  .Be( 0 );
        }
    }
}