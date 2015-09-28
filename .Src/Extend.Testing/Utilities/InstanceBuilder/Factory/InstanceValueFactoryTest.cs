#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class InstanceValueFactoryTest
    {
        [Test]
        public void AddConditionTest()
        {
            var target = new InstanceValueFactory( x => "" );
            var expectedCondition = new ParentTypeInstanceBuilderCondition( typeof (String) );
            target.Conditions.Add( expectedCondition );

            target.Conditions.Contains( expectedCondition )
                  .Should()
                  .BeTrue();
            target.Conditions.Count.Should()
                  .Be( 1 );
        }

        [Test]
        public void CtorTest()
        {
            Func<IInstanceValueArguments, Object> factory = x => "";
            var target = new InstanceValueFactory( factory );
            target.Factory.Should()
                  .BeSameAs( factory );

            target.Conditions.Count.Should()
                  .Be( 0 );
        }

        [Test]
        public void MatchesTest()
        {
            var target = new InstanceValueFactory( x => "" );
            target.Conditions.Add( new ExpressionInstanceBuilderCondition( x => true ) );
            target.Conditions.CombinationOption = ConditionCombinationOption.MatchAll;

            var actual = target.Matches( new InstanceValueArguments( typeof (String), "name", null, null ) );
            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void MatchesTest1()
        {
            var target = new InstanceValueFactory( x => "" );
            target.Conditions.Add( new ExpressionInstanceBuilderCondition( x => false ) );
            target.Conditions.CombinationOption = ConditionCombinationOption.MatchAny;

            var actual = target.Matches( new InstanceValueArguments( typeof (String), "name", null, null ) );
            actual.Should()
                  .BeFalse();
        }
    }
}