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
        public void GreaterOrEqualsTest()
        {
            var value = 1000;
            var value1 = 900;

            var actual = value.GreaterOrEquals( value1 );
            Assert.True( actual );

            value = 10;
            value1 = 900;

            actual = value.GreaterOrEquals( value1 );
            Assert.False( actual );

            value = 10;
            value1 = 10;

            actual = value.GreaterOrEquals( value1 );
            Assert.True( actual );
        }

        [Fact]
        public void GreaterOrEqualsTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IComparableTEx.GreaterOrEquals( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GreaterOrEqualsTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".GreaterOrEquals( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}