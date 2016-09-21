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