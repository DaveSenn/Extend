#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class InstanceBuilderConditionCollectionTest
    {
        [Test]
        public void CombinationOptionTest()

        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var target = new InstanceBuilderConditionCollection();
            var expected = RandomValueEx.GetRandomEnum<ConditionCombinationOption>();
            target.CombinationOption = expected;
            target.CombinationOption.Should()
                  .Be( expected );
        }

        [Test]
        public void MatchesTestMatchAllNoItems()

        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var target = new InstanceBuilderConditionCollection
            {
                CombinationOption = ConditionCombinationOption.MatchAll
            };
            var arguments = new InstanceValueArguments( typeof (String), "Name", null, null );
            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void MatchesTestMatchAnyMatch()

        {
            var target = new InstanceBuilderConditionCollection
            {
                new ExpressionInstanceBuilderCondition( x => true ),
                new ExpressionInstanceBuilderCondition( x => true )
            };
            target.CombinationOption = ConditionCombinationOption.MatchAny;
            var arguments = new InstanceValueArguments( typeof (String), "Name", null, null );
            var actual = target.Matches( arguments );
            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void MatchesTestMatchAnyMatch1()

        {
            var target = new InstanceBuilderConditionCollection
            {
                new ExpressionInstanceBuilderCondition( x => true ),
                new ExpressionInstanceBuilderCondition( x => false )
            };
            target.CombinationOption = ConditionCombinationOption.MatchAny;
            var arguments = new InstanceValueArguments( typeof (String), "Name", null, null );
            var actual = target.Matches( arguments );
            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void MatchesTestMatchAnyMatchNoMatch()

        {
            var target = new InstanceBuilderConditionCollection
            {
                new ExpressionInstanceBuilderCondition( x => false ),
                new ExpressionInstanceBuilderCondition( x => false )
            };
            target.CombinationOption = ConditionCombinationOption.MatchAny;
            var arguments = new InstanceValueArguments( typeof (String), "Name", null, null );
            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void MatchesTestMatchAnyNoItems()

        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var target = new InstanceBuilderConditionCollection
            {
                CombinationOption = ConditionCombinationOption.MatchAny
            };
            var arguments = new InstanceValueArguments( typeof (String), "Name", null, null );
            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void MatchesTestMatchMatch()

        {
            var target = new InstanceBuilderConditionCollection
            {
                new ExpressionInstanceBuilderCondition( x => true ),
                new ExpressionInstanceBuilderCondition( x => true )
            };
            target.CombinationOption = ConditionCombinationOption.MatchAll;
            var arguments = new InstanceValueArguments( typeof (String), "Name", null, null );
            var actual = target.Matches( arguments );
            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void MatchesTestMatchNoMatch()

        {
            var target = new InstanceBuilderConditionCollection
            {
                new ExpressionInstanceBuilderCondition( x => false ),
                new ExpressionInstanceBuilderCondition( x => true )
            };
            target.CombinationOption = ConditionCombinationOption.MatchAll;
            var arguments = new InstanceValueArguments( typeof (String), "Name", null, null );
            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void MatchesTestMatchNoMatch1()

        {
            var target = new InstanceBuilderConditionCollection
            {
                new ExpressionInstanceBuilderCondition( x => false ),
                new ExpressionInstanceBuilderCondition( x => false )
            };
            target.CombinationOption = ConditionCombinationOption.MatchAll;
            var arguments = new InstanceValueArguments( typeof (String), "Name", null, null );
            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void MatchesTestNotMatchAnyNoItems()

        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var target = new InstanceBuilderConditionCollection
            {
                CombinationOption = ConditionCombinationOption.NotMatchAny
            };
            var arguments = new InstanceValueArguments( typeof (String), "Name", null, null );
            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void MatchesTestNotMatchAnyNoItemsMatch()

        {
            var target = new InstanceBuilderConditionCollection
            {
                new ExpressionInstanceBuilderCondition( x => false ),
                new ExpressionInstanceBuilderCondition( x => false )
            };
            target.CombinationOption = ConditionCombinationOption.NotMatchAny;
            var arguments = new InstanceValueArguments( typeof (String), "Name", null, null );
            var actual = target.Matches( arguments );
            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void MatchesTestNotMatchAnyNoItemsNoMatch()

        {
            var target = new InstanceBuilderConditionCollection
            {
                new ExpressionInstanceBuilderCondition( x => true ),
                new ExpressionInstanceBuilderCondition( x => false )
            };
            target.CombinationOption = ConditionCombinationOption.NotMatchAny;
            var arguments = new InstanceValueArguments( typeof (String), "Name", null, null );
            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }

        [Test]
        public void MatchesTestNotMatchAnyNoItemsNoMatch1()

        {
            var target = new InstanceBuilderConditionCollection
            {
                new ExpressionInstanceBuilderCondition( x => true ),
                new ExpressionInstanceBuilderCondition( x => true )
            };
            target.CombinationOption = ConditionCombinationOption.NotMatchAny;
            var arguments = new InstanceValueArguments( typeof (String), "Name", null, null );
            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }
    }
}