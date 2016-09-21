#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class MemberSelectionRuleInspectorTest
    {
        [Test]
        public void InspectExcludeOnlyTest()
        {
            var target = new MemberSelectionRuleInspector();
            const MemberSelectionResult expected = MemberSelectionResult.ExcludeMember;

            var actual = target.Inspect( new List<IMemberSelectionRule>
                                         {
                                             new ExpressionMemberSelectionRule( x => true, MemberSelectionMode.Exclude )
                                         },
                                         new MemberInformation() );
            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void InspectExcludeOverwriteTest()
        {
            var target = new MemberSelectionRuleInspector();
            const MemberSelectionResult expected = MemberSelectionResult.ExcludeMember;

            var actual = target.Inspect( new List<IMemberSelectionRule>
                                         {
                                             new ExpressionMemberSelectionRule( x => true, MemberSelectionMode.Include ),
                                             new ExpressionMemberSelectionRule( x => false, MemberSelectionMode.Exclude ),
                                             new ExpressionMemberSelectionRule( x => true, MemberSelectionMode.Exclude )
                                         },
                                         new MemberInformation() );
            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void InspectIncludeOnlyTest()
        {
            var target = new MemberSelectionRuleInspector();
            const MemberSelectionResult expected = MemberSelectionResult.IncludeMember;

            var actual = target.Inspect( new List<IMemberSelectionRule>
                                         {
                                             new ExpressionMemberSelectionRule( x => true, MemberSelectionMode.Include )
                                         },
                                         new MemberInformation() );
            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void InspectIncludeOverwriteTest()
        {
            var target = new MemberSelectionRuleInspector();
            const MemberSelectionResult expected = MemberSelectionResult.IncludeMember;

            var actual = target.Inspect( new List<IMemberSelectionRule>
                                         {
                                             new ExpressionMemberSelectionRule( x => true, MemberSelectionMode.Exclude ),
                                             new ExpressionMemberSelectionRule( x => false, MemberSelectionMode.Include ),
                                             new ExpressionMemberSelectionRule( x => true, MemberSelectionMode.Include )
                                         },
                                         new MemberInformation() );
            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void InspectMemberInfoNullTest()
        {
            var target = new MemberSelectionRuleInspector();
            Action test = () => target.Inspect( new List<IMemberSelectionRule>(), null );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void InspectNoMatchingRulesTest()
        {
            var target = new MemberSelectionRuleInspector();
            const MemberSelectionResult expected = MemberSelectionResult.Neutral;

            var actual = target.Inspect( new List<IMemberSelectionRule>
                                         {
                                             new ExpressionMemberSelectionRule( x => false, MemberSelectionMode.Include ),
                                             new ExpressionMemberSelectionRule( x => false, MemberSelectionMode.Exclude )
                                         },
                                         new MemberInformation() );
            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void InspectNoRulesTest()
        {
            var target = new MemberSelectionRuleInspector();
            const MemberSelectionResult expected = MemberSelectionResult.Neutral;

            var actual = target.Inspect( new List<IMemberSelectionRule>(), new MemberInformation() );
            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void InspectRulesNullTest()
        {
            var target = new MemberSelectionRuleInspector();
            Action test = () => target.Inspect( null, new MemberInformation() );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}