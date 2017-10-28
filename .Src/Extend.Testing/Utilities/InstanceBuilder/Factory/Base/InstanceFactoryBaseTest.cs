#region Usings

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class InstanceFactoryBaseTest
    {
        [Fact]
        public void AddSelectionRuleArgumentNullExceptionTest()
        {
            var target = new InstanceFactoryBaseAccessor( "1", "2" );
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => target.AddSelectionRule( null );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddSelectionRuleTest()
        {
            var target = new InstanceFactoryBaseAccessor( "1", "2" );
            var expectedRule = new PathMemberSelectionRule( "Path", MemberSelectionMode.Include );
            var expectedFactory = target.AddSelectionRule( expectedRule );

            expectedFactory.Should()
                           .BeSameAs( target );
            expectedRule.Should()
                        .BeSameAs( target.SelectionRules.First() );
            target.SelectionRules.Count.Should()
                  .Be( 1 );
        }

        [Fact]
        public void CreateValueTest()
        {
            var target = new InstanceFactoryBaseAccessor( "1", "2" );
            Action test = () => target.CreateValue( new MemberInformation() );
            test.ShouldThrow<NotImplementedException>();
        }

        [Fact]
        public void FactoryDescriptionTest()
        {
            var target = new InstanceFactoryBaseAccessor( "1", "2" );
            target.FactoryDescription.Should()
                  .Be( "2" );
        }

        [Fact]
        public void FactoryNameTest()
        {
            var target = new InstanceFactoryBaseAccessor( "1", "2" );
            target.FactoryName.Should()
                  .Be( "1" );
        }

        [Fact]
        public void SelectionRulesTest()
        {
            var target = new InstanceFactoryBaseAccessor( "1", "2" );
            target.SelectionRules.Count.Should()
                  .Be( 0 );
        }

        [Fact]
        public void ToStringTest()
        {
            var target = new InstanceFactoryBaseAccessor( "1", "2" );
            const String expected = "[1] = (2).";
            var actual = target.ToString();
            actual.Should()
                  .Be( expected );
        }

        #region Nested Types

        private class InstanceFactoryBaseAccessor : InstanceFactoryBase
        {
            #region Ctor

            /// <summary>
            ///     Initializes a new instance of the <see cref="InstanceFactoryBase" /> class.
            /// </summary>
            /// <param name="name">The name of the factory.</param>
            /// <param name="description">The description of the factory.</param>
            public InstanceFactoryBaseAccessor( String name, String description )
                : base( name, description )
            {
            }

            #endregion

            #region Overrides of InstanceFactoryBase

            /// <summary>
            ///     Gets the value for the given <see cref="IMemberInformation" />.
            /// </summary>
            /// <param name="memberInformation">Information about the member to create a value for.</param>
            /// <returns>Returns the created value.</returns>
            public override Object CreateValue( IMemberInformation memberInformation )
                => throw new NotImplementedException();

            #endregion
        }

        #endregion
    }
}