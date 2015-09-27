#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class ParentTypeInstanceBuilderConditionTest
    {
        [Test]
        public void CtorTest()
        {
            var type = typeof (Int32);
            var target = new ParentTypeInstanceBuilderCondition( type );

            target.Type.Should()
                  .Be( type );
        }

        [Test]
        public void MatchesTestArgumentNullException()
        {
            var type = typeof (Int32);
            var arguments = new InstanceValueArguments( typeof (String), "MypRoperty", null, null );
            var target = new ParentTypeInstanceBuilderCondition( type );

            Action test = () => target.Matches( null );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MatchesTestMatch()
        {
            var type = typeof (String);
            var owner = String.Empty;
            var arguments = new InstanceValueArguments( type, "MypRoperty", null, owner );
            var target = new ParentTypeInstanceBuilderCondition( type );

            var actual = target.Matches( arguments );
            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void MatchesTestNoMatch()
        {
            var type = typeof (String);
            var arguments = new InstanceValueArguments( typeof (String), "MypRoperty", null, 222 );
            var target = new ParentTypeInstanceBuilderCondition( type );

            var actual = target.Matches( arguments );
            actual.Should()
                  .BeFalse();
        }
    }
}