#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class ExpressionMemberSelectionRuleTest
    {
        [Test]
        public void CheckMemberInPredicateIsSame()
        {
            var expected = new MemberInformation();
            MemberInformation actual = null;
            var target = new ExpressionMemberSelectionRule( x =>
                                                            {
                                                                actual = x as MemberInformation;
                                                                return true;
                                                            },
                                                            MemberSelectionMode.Include );

            var result = target.GetSelectionResult( expected );
            result.Should()
                  .Be( MemberSelectionResult.IncludeMember );

            actual.Should()
                  .BeSameAs( expected );
        }

        [Test]
        public void CtorTest()
        {
            var expectedName = RandomValueEx.GetRandomString();
            var expectedDescription = RandomValueEx.GetRandomString();
            var target = new ExpressionMemberSelectionRule( x => true, MemberSelectionMode.Include, expectedName, expectedDescription );

            target.RuleName.Should()
                  .Be( expectedName );
            target.RuleDescription.Should()
                  .Be( expectedDescription );
        }

        [Test]
        public void CtorTestPredicateNullTest()
        {
            Func<IMemberInformation, Boolean> predicate = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ObjectCreationAsStatement
            Action test = () => new ExpressionMemberSelectionRule( predicate, MemberSelectionMode.Include );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void PredicateFalseExcludeTest()
        {
            var target = new ExpressionMemberSelectionRule( x => false, MemberSelectionMode.Exclude );
            const MemberSelectionResult expected = MemberSelectionResult.Neutral;

            var actual = target.GetSelectionResult( new MemberInformation() );
            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void PredicateFalseIncludeTest()
        {
            var target = new ExpressionMemberSelectionRule( x => false, MemberSelectionMode.Include );
            const MemberSelectionResult expected = MemberSelectionResult.Neutral;

            var actual = target.GetSelectionResult( new MemberInformation() );
            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void PredicateTrueExcludeTest()
        {
            var target = new ExpressionMemberSelectionRule( x => true, MemberSelectionMode.Exclude );
            const MemberSelectionResult expected = MemberSelectionResult.ExcludeMember;

            var actual = target.GetSelectionResult( new MemberInformation() );
            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void PredicateTrueIncludeTest()
        {
            var target = new ExpressionMemberSelectionRule( x => true, MemberSelectionMode.Include );
            const MemberSelectionResult expected = MemberSelectionResult.IncludeMember;

            var actual = target.GetSelectionResult( new MemberInformation() );
            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void ToStringExcludeTest()
        {
            var target = new ExpressionMemberSelectionRule( x => true, MemberSelectionMode.Exclude );
            const String expected = "[] = (Exclude members matching predicate) ().";

            var actual = target.ToString();
            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void ToStringIncludeTest()
        {
            var target = new ExpressionMemberSelectionRule( x => true, MemberSelectionMode.Include, "A", "B" );
            const String expected = "[A] = (Include members matching predicate) (B).";

            var actual = target.ToString();
            actual.Should()
                  .Be( expected );
        }
    }
}