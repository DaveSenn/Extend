#region Usings

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void SatisfiesWithMessagesTest()
        {
            var specification = new ExpressionSpecification<String>( x => x.Length > 3 )
                .And( x => x.StartsWith( "1", StringComparison.Ordinal ) );

            var actual = "1234".SatisfiesWithMessages( specification )
                               .ToList();
            Assert.Empty( actual );
        }

        [Fact]
        public void SatisfiesWithMessagesTest1()
        {
            var specification = new ExpressionSpecification<String>( x => x.Length > 3 )
                .And( x => x.StartsWith( "1", StringComparison.Ordinal ) );

            var actual = "234".SatisfiesWithMessages( specification )
                              .ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Null( actual[0] );
            Assert.Null( actual[1] );
        }

        [Fact]
        public void SatisfiesWithMessagesTest2()
        {
            var specification = new ExpressionSpecification<String>( x => x.Length > 3, "msg1" )
                .And( x => x.StartsWith( "1", StringComparison.Ordinal ), "msg2" );

            var actual = "234".SatisfiesWithMessages( specification )
                              .ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Equal( 1, actual.Count( x => x == "msg1" ) );
            Assert.Equal( 1, actual.Count( x => x == "msg2" ) );
        }

        [Fact]
        public void SatisfiesWithMessagesTestnullCheck()
        {
            ISpecification<String> specification = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "1234".SatisfiesWithMessages( specification );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}