﻿#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class AllMemberSelectionRuleTest
    {
        [Test]
        public void CtorTest()
        {
            var expected = RandomValueEx.GetRandomEnum<MemberSelectionMode>();
            var expectedName = RandomValueEx.GetRandomString();
            var expectedDescription = RandomValueEx.GetRandomString();
            var target = new AllMemberSelectionRule( expected, expectedName, expectedDescription );

            target.RuleName.Should()
                  .Be( expectedName );
            target.RuleDescription.Should()
                  .Be( expectedDescription );
        }

        [Test]
        public void GetSelectionResultTest()
        {
            var target = new AllMemberSelectionRule( MemberSelectionMode.Include );
            const MemberSelectionResult expected = MemberSelectionResult.IncludeMember;
            var actual = target.GetSelectionResult( new MemberInformation() );

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void GetSelectionResultTest1()
        {
            var target = new AllMemberSelectionRule( MemberSelectionMode.Exclude );
            const MemberSelectionResult expected = MemberSelectionResult.ExcludeMember;
            var actual = target.GetSelectionResult( new MemberInformation() );

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void ToStringExcludeAllTest()
        {
            var target = new AllMemberSelectionRule( MemberSelectionMode.Exclude );
            const String expected = "[] = (Exclude all members) ().";

            target
                .ToString()
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToStringIncludeAllTest()
        {
            var target = new AllMemberSelectionRule( MemberSelectionMode.Include, "Name", "Description" );
            const String expected = "[Name] = (Include all members) (Description).";

            target
                .ToString()
                .Should()
                .Be( expected );
        }
    }
}