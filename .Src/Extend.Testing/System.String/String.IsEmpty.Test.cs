#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void IsEmptyTest()
        {
            var value = "";
            Assert.True( value.IsEmpty() );

            value = null;
            Assert.True( value.IsEmpty() );

            value = "   ";
            Assert.True( value.IsEmpty() );

            value = RandomValueEx.GetRandomString();
            Assert.False( value.IsEmpty() );
        }
    }
}