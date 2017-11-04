#region Usings

using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class CharExTest
    {
        [Fact]
        public void IsDigitTest()
        {
            '0'.IsDigit()
               .Should()
               .BeTrue();
            '9'.IsDigit()
               .Should()
               .BeTrue();

            'a'.IsDigit()
               .Should()
               .BeFalse();
            'A'.IsDigit()
               .Should()
               .BeFalse();
            'z'.IsDigit()
               .Should()
               .BeFalse();
            '-'.IsDigit()
               .Should()
               .BeFalse();
        }
    }
}