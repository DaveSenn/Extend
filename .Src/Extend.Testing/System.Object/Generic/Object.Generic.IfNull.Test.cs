#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void IfNullTest()
        {
            var expected = RandomValueEx.GetRandomString();

            var actual = ObjectEx.IfNull( null, expected );
            Assert.Equal( expected, actual );

            actual = expected.IfNull( null );
            Assert.Equal( expected, actual );
        }
    }
}