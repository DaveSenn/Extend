#region Usings

using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class CharExTest
    {
        [Fact]
        public void IsNumberTest()
        {
            '0'.IsNumber()
               .Should()
               .BeTrue();
            '9'.IsNumber()
               .Should()
               .BeTrue();

            'a'.IsNumber()
               .Should()
               .BeFalse();
            'A'.IsNumber()
               .Should()
               .BeFalse();
            'z'.IsNumber()
               .Should()
               .BeFalse();
            '-'.IsNumber()
               .Should()
               .BeFalse();
        }
    }
}