#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void SatisfiesTest()
        {
            var specification = new ExpressionSpecification<String>( x => x.Length > 3 );
            var actual = "1234".Satisfies( specification );
            Assert.True( actual );
        }

        [Fact]
        public void SatisfiesTest1()
        {
            var specification = new ExpressionSpecification<String>( x => x.Length > 3 );
            var actual = "123".Satisfies( specification );
            Assert.False( actual );
        }

        [Fact]
        public void SatisfiesTestnullCheck()
        {
            ISpecification<String> specification = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "1234".Satisfies( specification );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}