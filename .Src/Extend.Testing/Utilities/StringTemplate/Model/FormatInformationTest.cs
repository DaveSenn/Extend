#region Usings

using Extend.Internal;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing.Internal
{
    public class FormatInformationTest
    {
        [Fact]
        public void FormatTest()
        {
            var expected = RandomValueEx.GetRandomString();
            var target = new FormatInformation( "name", expected );

            target.Format.Should()
                  .Be( expected );
        }

        [Fact]
        public void ValueNameTest()
        {
            var expected = RandomValueEx.GetRandomString();
            var target = new FormatInformation( expected, null );

            target.ValueName.Should()
                  .Be( expected );
        }
    }
}