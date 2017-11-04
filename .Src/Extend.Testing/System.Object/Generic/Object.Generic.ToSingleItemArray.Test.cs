#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void ToSingleItemArrayTest()
        {
            var item = RandomValueEx.GetRandomString();

            var actual = item.ToSingleItemArray();

            Assert.Single( actual );
            Assert.Equal( item, actual[0] );
        }
    }
}