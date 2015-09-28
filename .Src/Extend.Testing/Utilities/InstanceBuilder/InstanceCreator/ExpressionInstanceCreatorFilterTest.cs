#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing.Utilities.InstanceBuilder.InstanceCreator
{
    [TestFixture]
    public class ExpressionInstanceCreatorFilterTest
    {
        [Test]
        public void CtorTest()
        {
            Func<IInstanceValueArguments, Boolean> predicate = x => true;
            var name = RandomValueEx.GetRandomString();
            var description = RandomValueEx.GetRandomString();
            var target = new ExpressionInstanceCreatorFilter( predicate, name, description );

            target.Name.Should()
                  .Be( name );
            target.Description.Should()
                  .Be( description );
        }

        [Test]
        public void CtorTestArgumentNullException()
        {
            Action test = () => new ExpressionInstanceCreatorFilter( null, "", "" );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MatchesTestMatch()
        {
            IInstanceValueArguments actualArguments = null;
            var target = new ExpressionInstanceCreatorFilter(
                x =>
                {
                    actualArguments = x;
                    return true;
                },
                "name",
                "desc" );

            var expectedArguments = new InstanceValueArguments( typeof (String), "name", null, null );
            var actual = target.Matches( expectedArguments );

            actual.Should()
                  .BeTrue();
            actualArguments.Should()
                           .BeSameAs( expectedArguments );
        }

        [Test]
        public void MatchesTestNoMatch()
        {
            IInstanceValueArguments actualArguments = null;
            var target = new ExpressionInstanceCreatorFilter(
                x =>
                {
                    actualArguments = x;
                    return false;
                },
                "name",
                "desc" );

            var expectedArguments = new InstanceValueArguments( typeof (String), "name", null, null );
            var actual = target.Matches( expectedArguments );

            actual.Should()
                  .BeFalse();
            actualArguments.Should()
                           .BeSameAs( expectedArguments );
        }
    }
}