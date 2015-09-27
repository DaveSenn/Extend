#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class NameInstanceBuilderConditionTest
    {
        [Test]
        public void CtorTest()
        {
            var value = RandomValueEx.GetRandomString();
            var compareOption = RandomValueEx.GetRandomEnum<StringCompareOption>();
            var ignoreCase = RandomValueEx.GetRandomBoolean();
            var target = new NameInstanceBuilderCondition( value, compareOption, ignoreCase );

            target.Value.Should()
                  .Be( value );
            target.CompareOption.Should()
                  .Be( compareOption );
            target.IgnoreCase.Should()
                  .Be( ignoreCase );
        }

        [Test]
        public void MatchesTestArgumentNullException()
        {
            var target = new NameInstanceBuilderCondition( "name", StringCompareOption.Contains, true );

            Action test = () => target.Matches( null );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MatchesTestContains()
        {
            const String value = "my";
            const StringCompareOption compareOption = StringCompareOption.Contains;
            const Boolean ignoreCase = false;
            var arguments = new InstanceValueArguments( typeof (String), "MyProperty", null, null );

            var target = new NameInstanceBuilderCondition( value, compareOption, ignoreCase );

            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void MatchesTestContainsIgnoreCase()
        {
            const String value = "my";
            const StringCompareOption compareOption = StringCompareOption.Contains;
            const Boolean ignoreCase = true;
            var arguments = new InstanceValueArguments( typeof (String), "MyProperty", null, null );

            var target = new NameInstanceBuilderCondition( value, compareOption, ignoreCase );

            var actual = target.Matches( arguments );
            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void MatchesTestEndsWithIgnoreCase()
        {
            const String value = "ty";
            const StringCompareOption compareOption = StringCompareOption.EndsWith;
            const Boolean ignoreCase = true;
            var arguments = new InstanceValueArguments( typeof (String), "MyProperty", null, null );

            var target = new NameInstanceBuilderCondition( value, compareOption, ignoreCase );

            var actual = target.Matches( arguments );
            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void MatchesTestEndsWithWith()
        {
            const String value = "property";
            const StringCompareOption compareOption = StringCompareOption.EndsWith;
            const Boolean ignoreCase = false;
            var arguments = new InstanceValueArguments( typeof (String), "MyProperty", null, null );

            var target = new NameInstanceBuilderCondition( value, compareOption, ignoreCase );

            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void MatchesTestEquals()
        {
            const String value = "myProperty";
            const StringCompareOption compareOption = StringCompareOption.Equals;
            const Boolean ignoreCase = false;
            var arguments = new InstanceValueArguments( typeof (String), "MyProperty", null, null );

            var target = new NameInstanceBuilderCondition( value, compareOption, ignoreCase );

            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void MatchesTestEqualsIgnoreCase()
        {
            const String value = "myProperty";
            const StringCompareOption compareOption = StringCompareOption.Equals;
            const Boolean ignoreCase = true;
            var arguments = new InstanceValueArguments( typeof (String), "MyProperty", null, null );

            var target = new NameInstanceBuilderCondition( value, compareOption, ignoreCase );

            var actual = target.Matches( arguments );
            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void MatchesTestStartsWith()
        {
            const String value = "my";
            const StringCompareOption compareOption = StringCompareOption.StartsWith;
            const Boolean ignoreCase = false;
            var arguments = new InstanceValueArguments( typeof (String), "MyProperty", null, null );

            var target = new NameInstanceBuilderCondition( value, compareOption, ignoreCase );

            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void MatchesTestStartsWithIgnoreCase()
        {
            const String value = "my";
            const StringCompareOption compareOption = StringCompareOption.StartsWith;
            const Boolean ignoreCase = true;
            var arguments = new InstanceValueArguments( typeof (String), "MyProperty", null, null );

            var target = new NameInstanceBuilderCondition( value, compareOption, ignoreCase );

            var actual = target.Matches( arguments );
            actual.Should()
                  .BeTrue();
        }
    }
}