#region Usings

using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class MemberSelectionResultExTest
    {
        [Test]
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