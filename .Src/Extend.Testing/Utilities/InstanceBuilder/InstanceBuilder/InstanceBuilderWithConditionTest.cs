#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class InstanceBuilderWithConditionTest
    {
        [Test]
        public void CtorTest()
        {
            var instanceBuilder = new InstanceBuilder( typeof (String) );
            IInstanceValueFactory factory = new InstanceValueFactory( x => "" );
            var target = new InstanceBuilderWithCondition( instanceBuilder, factory );

            target.Should()
                  .NotBeNull();
        }

        [Test]
        public void WithConditionCombinationTest()
        {
            var instanceBuilder = new InstanceBuilder( typeof (String) );
            IInstanceValueFactory factory = new InstanceValueFactory( x => "" );
            var target = new InstanceBuilderWithCondition( instanceBuilder, factory );

            var actual = target.WithConditionCombination( ConditionCombinationOption.MatchAny );
            actual.Should()
                  .BeSameAs( target );
        }

        [Test]
        public void WithConditionTest()
        {
            var instanceBuilder = new InstanceBuilder( typeof (String) );
            IInstanceValueFactory factory = new InstanceValueFactory( x => "" );
            var target = new InstanceBuilderWithCondition( instanceBuilder, factory );

            var actual = target.WithCondition( new ExpressionInstanceBuilderCondition( x => true ) );
            actual.Should()
                  .BeSameAs( target );
        }

        [Test]
        public void WithConditionTestArgumentNullException()
        {
            var instanceBuilder = new InstanceBuilder( typeof (String) );
            IInstanceValueFactory factory = new InstanceValueFactory( x => "" );
            var target = new InstanceBuilderWithCondition( instanceBuilder, factory );

            Action test = () => target.WithCondition( null );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void WithFactoryTest()
        {
            var target = new InstanceBuilderWithCondition( new InstanceBuilder( typeof (String) ), new InstanceValueFactory( x => "" ) );

            Func<IInstanceValueArguments, Object> factory = x => "";

            var actual = target.WithFactory( factory );
            actual.Should()
                  .NotBeNull();
        }

        [Test]
        public void WithFactoryTestArgumentNullException()
        {
            var instanceBuilder = new InstanceBuilder( typeof (String) );
            IInstanceValueFactory factory = new InstanceValueFactory( x => "" );
            var target = new InstanceBuilderWithCondition( instanceBuilder, factory );

            Action test = () => target.WithFactory( null );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}