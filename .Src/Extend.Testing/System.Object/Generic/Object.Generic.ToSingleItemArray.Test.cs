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

            Assert.Equal( 1, actual.Length );
            Assert.Equal( item, actual[0] );
        }
    }
}