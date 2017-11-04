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
        public void SpecificationTest()
        {
            var target = 11;
            var actual = target.Specification( x => x > 10 && x < 200 );

            var result = actual.IsSatisfiedBy( target );
            Assert.True( result );

            target = 200;
            result = actual.IsSatisfiedBy( target );
            Assert.False( result );
        }

        [Fact]
        public void SpecificationTestNullCheck()
        {
            Func<Int32, Boolean> expression = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 11.Specification( expression );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}