#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ComparableTExTest
    {
        [Fact]
        public void SmallerOrEqualsTest()
        {
            var value = 1000;
            var value1 = 900;

            var actual = value.SmallerOrEquals( value1 );
            Assert.False( actual );

            value = 10;
            value1 = 900;

            actual = value.SmallerOrEquals( value1 );
            Assert.True( actual );

            value = 10;
            value1 = 10;

            actual = value.SmallerOrEquals( value1 );
            Assert.True( actual );
        }

        [Fact]
        public void SmallerOrEqualsTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IComparableTEx.SmallerOrEquals( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SmallerOrEqualsTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".SmallerOrEquals( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}