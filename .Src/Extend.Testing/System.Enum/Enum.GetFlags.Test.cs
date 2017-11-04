#region Usings

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class EnumExTest
    {
        [Fact]
        public void GetFlagsTest()
        {
            const RegexOptions enumValue = RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Multiline | RegexOptions.None;
            var actual = enumValue
                .GetFlags<RegexOptions>()
                .ToList();

            actual.Should()
                  .HaveCount( 4 );
            actual.Should()
                  .Contain( new List<RegexOptions> { RegexOptions.Compiled, RegexOptions.CultureInvariant, RegexOptions.Multiline, RegexOptions.None } );
        }
    }
}