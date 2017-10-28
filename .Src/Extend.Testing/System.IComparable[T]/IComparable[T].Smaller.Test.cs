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
        public void SmallerTest()
        {
            var value = 1000;
            var value1 = 900;

            var actual = value.Smaller( value1 );
            Assert.False( actual );

            value = 10;
            value1 = 900;

            actual = value.Smaller( value1 );
            Assert.True( actual );

            value = 10;
            value1 = 10;

            actual = value.Smaller( value1 );
            Assert.False( actual );
        }

        [Fact]
        public void SmallerTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IComparableTEx.Smaller( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SmallerTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".Smaller( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}