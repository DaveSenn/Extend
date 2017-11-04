#region Usings

using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class CharExTest
    {
        [Fact]
        public void IsLetterOrDigitTest()
        {
            '0'.IsLetterOrDigit()
               .Should()
               .BeTrue();
            '9'.IsLetterOrDigit()
               .Should()
               .BeTrue();

            'a'.IsLetterOrDigit()
               .Should()
               .BeTrue();
            'A'.IsLetterOrDigit()
               .Should()
               .BeTrue();
            'z'.IsLetterOrDigit()
               .Should()
               .BeTrue();
            '-'.IsLetterOrDigit()
               .Should()
               .BeFalse();
        }
    }
}