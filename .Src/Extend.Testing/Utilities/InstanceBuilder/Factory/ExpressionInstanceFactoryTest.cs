#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class ExpressionInstanceFactoryTest
    {
        [Test]
        public void AddMemberSelectionRuleTest()
        {
            var target = new ExpressionInstanceFactory( x => String.Empty );
            target.AddSelectionRule( new AllMemberSelectionRule( MemberSelectionMode.Include ) );
            target.Should()
                  .NotBeNull();
        }

        [Test]
        public void AddMemberSelectionRuleTestArgumentNullException()
        {
            var target = new ExpressionInstanceFactory( x => String.Empty );
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => target.AddSelectionRule( null );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CreateValueTest()
        {
            var expectedValue = RandomValueEx.GetRandomInt32();
            var expectedMemberInformation = new MemberInformation();
            IMemberInformation actualParameter = null;
            var target = new ExpressionInstanceFactory( x =>
                                                        {
                                                            actualParameter = x;
                                                            return expectedValue;
                                                        } );

            var actual = target.CreateValue( expectedMemberInformation );
            actual.Should()
                  .Be( expectedValue );
            actualParameter.Should()
                           .BeSameAs( expectedMemberInformation );
        }

        [Test]
        public void CtorTest()
        {
            var expectedName = RandomValueEx.GetRandomString();
            var expectedDescription = RandomValueEx.GetRandomString();
            var target = new ExpressionInstanceFactory( x => "", expectedName, expectedDescription );

            target.FactoryName.Should()
                  .Be( expectedName );
            target.FactoryDescription.Should()
                  .Be( expectedDescription );
        }

        [Test]
        public void CtorTestArgumentNullException()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ObjectCreationAsStatement
            Action test = () => new ExpressionInstanceFactory( null );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToStringIncludeAllTest()
        {
            var target = new ExpressionInstanceFactory( x => "", "name", "description" );
            const String expected = "[name] = (description).";

            target
                .ToString()
                .Should()
                .Be( expected );
        }
    }
}