#region Usings

using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [Test]
        public void IsEvenOTest()
        {
            var actual = Int64Ex.IsEven( 0 );
            actual.Should()
                  .Be( true );
        }

        [Test]
        public void IsEvenTest()
        {
            var value = RandomValueEx.GetRandomInt32();

            var expected = value % 2 == 0;
            var actual = Int64Ex.IsEven( value );
            actual.Should()
                  .Be( expected );
        }
    }
}