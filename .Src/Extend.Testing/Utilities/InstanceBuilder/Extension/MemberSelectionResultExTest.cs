#region Usings

using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class MemberSelectionResultExTest
    {
        [Fact]
        public void AsBooleanTest()
        {
            MemberSelectionResult.IncludeMember.AsBoolean()
                                 .Should()
                                 .BeTrue();
            MemberSelectionResult.ExcludeMember.AsBoolean()
                                 .Should()
                                 .BeFalse();
            MemberSelectionResult.Neutral.AsBoolean()
                                 .Should()
                                 .Be( null );
        }
    }
}