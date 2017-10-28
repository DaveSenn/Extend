#region Usings

using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int64ExTest
    {
        [Fact]
        public void IsEvenOTest()
        {
            var actual = Int64Ex.IsEven( 0 );
            actual.Should()
                  .Be( true );
        }

        [Fact]
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