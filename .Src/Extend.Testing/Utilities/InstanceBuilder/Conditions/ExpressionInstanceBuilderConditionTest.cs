#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class ExpressionInstanceBuilderConditionTest
    {
        [Test]
        public void CtorTest()
        {
            Func<IInstanceValueArguments, Boolean> predicate = x => true;
            var target = new ExpressionInstanceBuilderCondition( predicate );

            target.Predicate.Should()
                  .BeSameAs( predicate );
        }

        [Test]
        public void MatchesTest()
        {
            var expectedArguments = new InstanceValueArguments( typeof (String), "name", null, null );
            IInstanceValueArguments actualArguments = null;
            var target = new ExpressionInstanceBuilderCondition( x =>
            {
                actualArguments = x;
                return true;
            } );

            var actual = target.Matches( expectedArguments );
            actual.Should()
                  .BeTrue();
            actualArguments.Should()
                           .BeSameAs( expectedArguments );
        }

        [Test]
        public void MatchesTest1()
        {
            var expectedArguments = new InstanceValueArguments( typeof (String), "name", null, null );
            IInstanceValueArguments actualArguments = null;
            var target = new ExpressionInstanceBuilderCondition( x =>
            {
                actualArguments = x;
                return false;
            } );

            var actual = target.Matches( expectedArguments );
            actual.Should()
                  .BeFalse();
            actualArguments.Should()
                           .BeSameAs( expectedArguments );
        }

        [Test]
        public void MatchesTestArgumentNullException()
        {
            var target = new ExpressionInstanceBuilderCondition( x => true );

            Action test = () => target.Matches( null );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}