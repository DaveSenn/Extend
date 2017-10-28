#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void IsNullTest()
        {
            var value = RandomValueEx.GetRandomString();
            var actual = value.IsNull();

            Assert.False( actual );

            value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            actual = value.IsNull();

            Assert.True( actual );
        }
    }
}