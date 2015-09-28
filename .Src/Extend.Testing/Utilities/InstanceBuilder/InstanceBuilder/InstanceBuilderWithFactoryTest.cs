#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class InstanceBuilderWithFactoryTest
    {
        [Test]
        public void CtorTest()
        {
            var target = new InstanceBuilderWithFactory( new InstanceBuilder( typeof (String) ), x => "" );
            target.Should()
                  .NotBeNull();
        }

        [Test]
        public void WithConditionTest()
        {
            var target = new InstanceBuilderWithFactory( new InstanceBuilder( typeof (String) ), x => "" );
            var actual = target.WithCondition( new ExpressionInstanceBuilderCondition( x => true ) );

            actual.Should()
                  .NotBeNull();
        }
    }
}