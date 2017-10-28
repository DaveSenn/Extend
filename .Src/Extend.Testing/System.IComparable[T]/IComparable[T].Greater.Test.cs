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
        public void GreaterTest()
        {
            var value = 1000;
            var value1 = 900;

            var actual = value.Greater( value1 );
            Assert.True( actual );

            value = 10;
            value1 = 900;

            actual = value.Greater( value1 );
            Assert.False( actual );

            value = 10;
            value1 = 10;

            actual = value.Greater( value1 );
            Assert.False( actual );
        }

        [Fact]
        public void GreaterTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IComparableTEx.Greater( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GreaterTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".Greater( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}