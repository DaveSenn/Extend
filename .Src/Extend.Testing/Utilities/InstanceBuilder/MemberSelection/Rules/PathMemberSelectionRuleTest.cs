#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class PathMemberSelectionRuleTest
    {
        [Test]
        public void CtorPathNullTest()
        {
            Action test = () => new PathMemberSelectionRule( null, MemberSelectionMode.Include );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CtorTest()
        {
            var expectedName = RandomValueEx.GetRandomString();
            var expectedDescription = RandomValueEx.GetRandomString();
            var target = new PathMemberSelectionRule( "path", MemberSelectionMode.Include, expectedName, expectedDescription );

            target.RuleName.Should()
                  .Be( expectedName );
            target.RuleDescription.Should()
                  .Be( expectedDescription );
        }

        [Test]
        public void GetSelectionResultTest()
        {
            var target = new PathMemberSelectionRule( "A.B.C.MyString", MemberSelectionMode.Include );
            const MemberSelectionResult expected = MemberSelectionResult.IncludeMember;
            var actual = target.GetSelectionResult( new MemberInformation
            {
                MemberPath = "A.B.C.MyString"
            } );

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void GetSelectionResultTest1()
        {
            var target = new PathMemberSelectionRule( "A.B.C.MyString", MemberSelectionMode.Exclude );
            const MemberSelectionResult expected = MemberSelectionResult.ExcludeMember;
            var actual = target.GetSelectionResult( new MemberInformation
            {
                MemberPath = "A.B.C.MyString"
            } );

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void GetSelectionResultTest2()
        {
            var target = new PathMemberSelectionRule( "A.B.C", MemberSelectionMode.Include );
            const MemberSelectionResult expected = MemberSelectionResult.Neutral;
            var actual = target.GetSelectionResult( new MemberInformation
            {
                MemberPath = "A.B.C.MyString"
            } );

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void GetSelectionResultTest3()
        {
            var target = new PathMemberSelectionRule( "A.B.C", MemberSelectionMode.Exclude );
            const MemberSelectionResult expected = MemberSelectionResult.Neutral;
            var actual = target.GetSelectionResult( new MemberInformation
            {
                MemberPath = "A.B.C.MyString"
            } );

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void ToStringTest()
        {
            var target = new PathMemberSelectionRule( "A.B.C", MemberSelectionMode.Include );
            const String expected = "[] = (Include members at A.B.C) ().";
            var actual = target.ToString();

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void ToStringTest1()
        {
            var target = new PathMemberSelectionRule( "A.B", MemberSelectionMode.Exclude, "N", "D" );
            const String expected = "[N] = (Exclude members at A.B) (D).";
            var actual = target.ToString();

            actual.Should()
                  .Be( expected );
        }
    }
}