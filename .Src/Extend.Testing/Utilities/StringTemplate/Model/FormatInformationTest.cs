#region Usings

using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Internal.Testing
{
    [TestFixture]
    public class FormatInformationTest
    {
        [Test]
        public void FormatTest()
        {
            var expected = RandomValueEx.GetRandomString();
            var target = new FormatInformation( "name", expected );

            target.Format.Should()
                  .Be( expected );
        }

        [Test]
        public void ValueNameTest()
        {
            var expected = RandomValueEx.GetRandomString();
            var target = new FormatInformation( expected, null );

            target.ValueName.Should()
                  .Be( expected );
        }
    }
}