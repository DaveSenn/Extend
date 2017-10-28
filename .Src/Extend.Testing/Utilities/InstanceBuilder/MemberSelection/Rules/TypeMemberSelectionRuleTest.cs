#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class TypeMemberSelectionRuleTest
    {
        [Fact]
        public void CtorTest()
        {
            var expectedName = RandomValueEx.GetRandomString();
            var expectedDescription = RandomValueEx.GetRandomString();
            var target = new TypeMemberSelectionRule( typeof(String), MemberSelectionMode.Include, CompareMode.Is, expectedName, expectedDescription );

            target.RuleName.Should()
                  .Be( expectedName );
            target.RuleDescription.Should()
                  .Be( expectedDescription );
        }

        [Fact]
        public void CtorTypeNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ObjectCreationAsStatement
            Action test = () => new TypeMemberSelectionRule( null, MemberSelectionMode.Include, CompareMode.Is );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetSelectionResultTest()
        {
            var target = new TypeMemberSelectionRule( typeof(String), MemberSelectionMode.Include, CompareMode.Is );
            const MemberSelectionResult expected = MemberSelectionResult.IncludeMember;

            var actual = target.GetSelectionResult( new MemberInformation { MemberType = typeof(String) } );
            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetSelectionResultTest1()
        {
            var target = new TypeMemberSelectionRule( typeof(String), MemberSelectionMode.Include, CompareMode.Is );
            const MemberSelectionResult expected = MemberSelectionResult.Neutral;

            var actual = target.GetSelectionResult( new MemberInformation { MemberType = typeof(Int32) } );
            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetSelectionResultTest2()
        {
            var target = new TypeMemberSelectionRule( typeof(String), MemberSelectionMode.Include, CompareMode.IsNot );
            const MemberSelectionResult expected = MemberSelectionResult.Neutral;

            var actual = target.GetSelectionResult( new MemberInformation { MemberType = typeof(String) } );
            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetSelectionResultTest3()
        {
            var target = new TypeMemberSelectionRule( typeof(String), MemberSelectionMode.Include, CompareMode.IsNot );
            const MemberSelectionResult expected = MemberSelectionResult.IncludeMember;

            var actual = target.GetSelectionResult( new MemberInformation { MemberType = typeof(Int32) } );
            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetSelectionResultTest4()
        {
            var target = new TypeMemberSelectionRule( typeof(String), MemberSelectionMode.Exclude, CompareMode.Is );
            const MemberSelectionResult expected = MemberSelectionResult.ExcludeMember;

            var actual = target.GetSelectionResult( new MemberInformation { MemberType = typeof(String) } );
            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetSelectionResultTest5()
        {
            var target = new TypeMemberSelectionRule( typeof(String), MemberSelectionMode.Exclude, CompareMode.Is );
            const MemberSelectionResult expected = MemberSelectionResult.Neutral;

            var actual = target.GetSelectionResult( new MemberInformation { MemberType = typeof(Int32) } );
            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetSelectionResultTest6()
        {
            var target = new TypeMemberSelectionRule( typeof(String), MemberSelectionMode.Exclude, CompareMode.IsNot );
            const MemberSelectionResult expected = MemberSelectionResult.Neutral;

            var actual = target.GetSelectionResult( new MemberInformation { MemberType = typeof(String) } );
            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetSelectionResultTest7()
        {
            var target = new TypeMemberSelectionRule( typeof(String), MemberSelectionMode.Exclude, CompareMode.IsNot );
            const MemberSelectionResult expected = MemberSelectionResult.ExcludeMember;

            var actual = target.GetSelectionResult( new MemberInformation { MemberType = typeof(Int32) } );
            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void ToStringTest()
        {
            var target = new TypeMemberSelectionRule( typeof(String), MemberSelectionMode.Include, CompareMode.Is );
            const String expected = "[] = (Include where type Is String) ().";

            var actual = target.ToString();
            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void ToStringTest1()
        {
            var target = new TypeMemberSelectionRule( typeof(Int32), MemberSelectionMode.Exclude, CompareMode.Is, "X", "Y" );
            const String expected = "[X] = (Exclude where type Is Int32) (Y).";

            var actual = target.ToString();
            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void ToStringTest2()
        {
            var target = new TypeMemberSelectionRule( typeof(Double), MemberSelectionMode.Include, CompareMode.IsNot, "1", "2" );
            const String expected = "[1] = (Include where type IsNot Double) (2).";

            var actual = target.ToString();
            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void ToStringTest3()
        {
            var target = new TypeMemberSelectionRule( typeof(Char), MemberSelectionMode.Exclude, CompareMode.IsNot, "10", "100" );
            const String expected = "[10] = (Exclude where type IsNot Char) (100).";

            var actual = target.ToString();
            actual.Should()
                  .Be( expected );
        }
    }
}