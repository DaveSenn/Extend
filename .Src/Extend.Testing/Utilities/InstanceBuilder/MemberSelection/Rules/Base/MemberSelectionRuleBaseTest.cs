#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class MemberSelectionRuleBaseTest
    {
        [Fact]
        public void GetSelectionResultTest()
        {
            var target = new MemberSelectionRuleBaseAccessor( "Name", "Description" );
            Action test = () => target.GetSelectionResult( new MemberInformation() );
            test.ShouldThrow<NotImplementedException>();
        }

        [Fact]
        public void RuleDescriptionNameTest()
        {
            var target = new MemberSelectionRuleBaseAccessor( "Name", "Description" );
            target.RuleDescription.Should()
                  .Be( "Description" );
        }

        [Fact]
        public void RuleNameTest()
        {
            var target = new MemberSelectionRuleBaseAccessor( "Name", "Description" );
            target.RuleName.Should()
                  .Be( "Name" );
        }

        #region Nested Types

        private class MemberSelectionRuleBaseAccessor : MemberSelectionRuleBase
        {
            #region Ctor

            /// <summary>
            ///     Initializes a new instance of the <see cref="MemberSelectionRuleBase" /> class.
            /// </summary>
            /// <param name="name">The name of the rule.</param>
            /// <param name="description">The description of the rule.</param>
            public MemberSelectionRuleBaseAccessor( String name, String description )
                : base( name, description )
            {
            }

            #endregion

            #region Overrides of MemberSelectionRuleBase

            /// <summary>
            ///     Gets the selection result for the given member.
            /// </summary>
            /// <param name="member">The member to get the selection result for.</param>
            /// <returns>Returns the selection result for the given member.</returns>
            public override MemberSelectionResult GetSelectionResult( IMemberInformation member )
                => throw new NotImplementedException();

            #endregion
        }

        #endregion
    }
}