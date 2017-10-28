#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int16ExTest
    {
        [Fact]
        public void IsOddTest()
        {
            var value = RandomValueEx.GetRandomInt16();

            var expected = value % 2 != 0;
            var actual = value.IsOdd();
            Assert.Equal( expected, actual );
        }
    }
}