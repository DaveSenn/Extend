#region Usings

using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [Test]
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